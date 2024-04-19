using BeautySalon.Context;
using BeautySalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BeautySalon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BsContext _context;

        public HomeController(ILogger<HomeController> logger, BsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<CategoryService> categoryServices = _context.CategoriesServices.ToList();
            //ar a = _context.Services.Include(s => s.CategoriesServices).FirstOrDefault();
            return View(categoryServices);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> MastersByCategory(int categoryId) 
        {
            CategoryService cat = await _context.CategoriesServices.FirstOrDefaultAsync(c => c.CategoryId==categoryId);
            ViewBag.Category = cat != null ? cat.NameCategory : "";
            List<Employee> employees = await _context.EmployeeCategories
                .Where(c=>c.CategoryId==categoryId)
                .Include(e => e.Employee).ThenInclude(s => s.Specialization)
                .Include(c => c.CategoryService)
                .Select(e => e.Employee)
                .ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> RecordToMaster(int masterId)
        {
            Employee employee = await _context.Employees
                .Include(s => s.Specialization)
                .Include(c => c.CategoryServices)
                .ThenInclude(s => s.Services)
                .SingleOrDefaultAsync(e => e.EmployeeId==masterId);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> SaveRecord(int employeeId, int serviceId, DateTime dateRecord, TimeSpan timeRecord, 
              string clientNumber, string clientName)
        {
            try
            {
                Client client = await _context.Clients
                    .SingleOrDefaultAsync(n => n.PhoneNumber == clientNumber);
                if (client == null)
                {
                    client = new();
                    client.PhoneNumber = clientNumber;
                }
                client.ClientName = clientName;

                Record record = new Record
                {
                    DateRecording = dateRecord,
                    TimeRecording = timeRecord,
                    EmployeeId = employeeId,
                    ServiceId = serviceId,
                    Client = client
                };
                await _context.AddAsync(record);
                int resultsave = await _context.SaveChangesAsync();

                if (resultsave > 0)
                {
                    Employee employee = await _context.Employees.SingleOrDefaultAsync(e => e.EmployeeId == employeeId);

                    return Json($"{clientName} Вы записаны {dateRecord.ToString("d")} в {timeRecord} к мастеру {employee.Firstname}.");
                }
                else
                {
                    return StatusCode(503);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(503);
            }
            
            
        }

        public async Task<IActionResult> AboutUs()
        {
            AboutUs aboutUs = await _context.AboutUss.FirstOrDefaultAsync();
            return View(aboutUs);
        }
        
    }

}
