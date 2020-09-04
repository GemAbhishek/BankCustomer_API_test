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
        readonly log4net.ILog _log4net;

        private readonly ApplicationDbContext db;

        public SellController(ApplicationDbContext _db)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(SellController));

            db = _db;
        }

        [HttpPut("{id}/{qty}")]
        public IActionResult Put(int id, int qty)
        {
            _log4net.Info("PUT Request --- Sell update for id --"+id);

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
