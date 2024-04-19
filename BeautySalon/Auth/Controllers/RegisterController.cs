using BeautySalon.Auth.BLL;
using BeautySalon.Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.Auth.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAuthService _service;

        public RegisterController(IAuthService service)
        {
            _service = service;
        }

        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost(template: "login")]
        public async Task<IResult> Login(User request)
        {
            var result = await _service.Login(request);
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            Role newRole = new Role()
            {
                Name = "admin"
            };
            User user = new User { 
                Email = "admin@admin",
                PasswordString = "1",
                Role = newRole,
                EmployeeId = 1
            };
            Register(user);
            return View();
        }

        [AllowAnonymous]
        [HttpPost(template: "register")]
        public async Task<IResult> Register(User request)
        {
            var result = await _service.Register(request);
            return result;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult TestAuth()
        {
            return View();
        }
 }

}
