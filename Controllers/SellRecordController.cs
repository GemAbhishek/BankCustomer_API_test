using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRepositoryDemo.Model;
using BookRepositoryDemo.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookRepositoryDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellRecordController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        ISellRecordRepo isellRecord;

        public SellRecordController(ISellRecordRepo _db)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(SellRecordController));

            isellRecord = _db;
        }

        // GET: api/<BookController>
        [HttpGet]
        public IActionResult Get()
        {
            _log4net.Info(" Http GET request All Record requsted");

            List<SellRecord> sellRecord = new List<SellRecord>();

            sellRecord= isellRecord.GetDetails();

            return Ok(sellRecord);

        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _log4net.Info(" Http GET request by Id requested id = " + id);

            return Ok(isellRecord.GetDetail(id));
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post([FromBody] SellRecord obj)
        {
            _log4net.Info(" Http Post request");
            int isDone = isellRecord.AddDetail(obj);
            if(isDone == 1)
            {
                return Ok("Sell Record Added");
            }
            return NotFound("Error");
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SellRecord obj)
        {
            _log4net.Info("PUT ---Update Request");

            int isDone = isellRecord.UpdateDetail(id, obj);
            if(isDone == 1)
            {
                return Ok("Updated");
            }
            return NotFound("Record not Found");

        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _log4net.Info(" Delete requsted");
            int isDone = isellRecord.DeleteDetail(id);
            if (isDone == 1)
            {
                return Ok("Removed");
            }
            return NotFound("Error---Not Found");
        }
    }
}
