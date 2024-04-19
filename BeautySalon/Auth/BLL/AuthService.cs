using BeautySalon.Auth.Context;
using BeautySalon.Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.Auth.BLL
{
    public interface IAuthService
    {
        Task<IResult> Login(User user);
        Task<IResult> Register(User user);
    }

    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly IEncryptService _encryptService;
        private readonly AuthContext _context;

        public AuthService(AuthContext context, ITokenService tokenService, IEncryptService encryptService)
        {
            _tokenService = tokenService;
            _context = context;
            _encryptService = encryptService;
        }

        public async Task<IResult> Login(User request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (user is null)
            {
                return Results.NotFound();
            }

            var password = _encryptService.HashPassword(request.PasswordString, user.Salt);
            if (!user.Password.SequenceEqual(password))
            {
                return Results.BadRequest();
            }

            var role = await _context.Roles.FirstAsync(x => x.Id == user.RoleId);

            var token = _tokenService.GenerateToken(user.Email, role.Name.ToString());
            return Results.Ok(token);
        }

        public async Task<IResult> Register(User request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (user is not null)
            {
                return Results.Conflict();
            }
            var role = await _context.Roles.FirstAsync(x => x.Name == request.Role.Name.ToString());
            var salt = _encryptService.GenerateSalt();
            user = new User
            {
                Email = request.Email,
                Salt = salt,
                Password = _encryptService.HashPassword(request.PasswordString, salt),
                RoleId = role.Id,
                EmployeeId = request.EmployeeId
            };

            

            await _context.Users.AddAsync(user);
            try 
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex) 
            {
                var a = ex.Message;
            }

            

            var token = _tokenService.GenerateToken(user.Email, role.Name.ToString());
            return Results.Ok(token);
        }

    }
}
