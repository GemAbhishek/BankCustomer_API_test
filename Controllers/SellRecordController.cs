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
        readonly log4net.ILog _log4net;
        private readonly ApplicationDbContext db;

        public SellRecordController(ApplicationDbContext _db)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(SellRecordController));

            db = _db;
        }

        // GET: api/<BookController>
        [HttpGet]
        public ActionResult<List<SellRecord>> Get()
        {
            _log4net.Info(" Http GET request All Record requsted");

            List<SellRecord> sellRecord = new List<SellRecord>();

            sellRecord= db.SellRecords.ToList();

            return Ok(sellRecord);

        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public SellRecord Get(int id)
        {
            _log4net.Info(" Http GET request by Id requested id = " + id);
            return db.SellRecords.Find(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public string Post([FromBody] SellRecord obj)
        {
            _log4net.Info(" Http Post request");
            db.SellRecords.Add(obj);
            db.SaveChanges();
            return "Sell Record Added";

        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SellRecord obj)
        {
            _log4net.Info("PUT ---Update Request");
            try
            {
                obj.Id = id;
                db.SellRecords.Update(obj);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                return BadRequest("Record not found \n----------------\n" + e);
            }
            
            return Ok("Updated Sell-Record");

        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _log4net.Info(" Delete requsted");
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
