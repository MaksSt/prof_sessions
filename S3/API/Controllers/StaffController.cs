using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Runtime.InteropServices.Marshalling;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        [HttpGet(Name = "GetUser")]
        public IEnumerable<Staff> Get() 
        {
            MaindbContext db = new MaindbContext();
            return db.Staff.ToList();
        }
        [HttpPost(Name = "Auth")]
        public Staff Auth(Staff staff)
        {
            MaindbContext db = new MaindbContext();
            return db.Staff.Where(s => s.КодСотрудника == staff.КодСотрудника).FirstOrDefault();
        }
    }
}
