using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRepositoryDemo.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookRepositoryDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellRecordController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public SellRecordController(ApplicationDbContext _db)
        {
            db = _db;
        }

        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<SellRecord> Get()
        {
            return db.SellRecords.ToList();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public SellRecord Get(int id)
        {
            return db.SellRecords.Find(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public string Post([FromBody] SellRecord obj)
        {
            db.SellRecords.Add(obj);
            db.SaveChanges();
            return "Sell Record Added";

        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] SellRecord obj)
        {
            SellRecord sellRec = db.SellRecords.Find(id);
            sellRec.BookName = obj.BookName;
            sellRec.date = obj.date;
            sellRec.Qty = obj.Qty;
            
            db.SaveChanges();
            return "Updated Sell-Record";
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            SellRecord selRec = db.SellRecords.Find(id);
            if (selRec != null)
            {
                db.SellRecords.Remove(selRec);
                db.SaveChanges();
                return "Removed";
            }
            return "Not Found";
        }
    }
}
