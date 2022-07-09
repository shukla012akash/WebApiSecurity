using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPITwo.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
      
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("admin")]
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> employeeLsit = new List<Employee>();

            employeeLsit.Add(new Employee { Address = "Noida", Id=1, Name="Akash" });
            employeeLsit.Add(new Employee { Address = "Moradabad", Id = 2, Name = "Himanshu" });
            employeeLsit.Add(new Employee { Address = "Sitapur", Id =3, Name = "Vikas" });
            employeeLsit.Add(new Employee { Address = "Bareilly", Id = 4, Name = "Ashish" });
            employeeLsit.Add(new Employee { Address = "lko", Id = 5, Name = "Adarsh" });

            return employeeLsit;
        }
    }
}