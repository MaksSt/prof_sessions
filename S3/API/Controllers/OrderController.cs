using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet(Name = "GetVisitors")]
        public IEnumerable<Dest> Get()
        {
            MaindbContext db = new MaindbContext();
            db.Visitors.Load();
            return db.Dests.ToList();
        }

        [HttpPost("edit")]
        public IActionResult Edit(Dest dest)
        {
            using (var db = new MaindbContext())
            {
                var Dest = db.Dests.Where(d => d.Ид == dest.Ид).FirstOrDefault();
                if (Dest == null)
                    return NotFound();

                Dest.ВремяУбытия = dest.ВремяУбытия;
                Dest.РазрешениеНаТерриторию = dest.РазрешениеНаТерриторию;

                db.SaveChanges();
                db.Dests.Load();

                return Ok(Dest);
            }
        }
    }
}
