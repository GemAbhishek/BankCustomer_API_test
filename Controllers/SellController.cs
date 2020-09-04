using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRepositoryDemo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookRepositoryDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public SellController(ApplicationDbContext _db)
        {
            db = _db;
        }

        [HttpPut("{id}/{qty}")]
        public IActionResult Put(int id, int qty)
        {
            SellRecord obj = db.SellRecords.Find(id);
            if (obj != null)
            {
                obj.SellQty += qty;
                obj.date = DateTime.Now;
                db.SaveChanges();

                return Ok("Updated Sell-Record");
            }
            return NotFound("Record Id Invalid");
        }
    }
}
