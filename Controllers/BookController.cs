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
    public class BookController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        private readonly ApplicationDbContext db;

        public BookController(ApplicationDbContext _db)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(SellRecordController));

            db = _db;
        }

        // GET: api/<BookController>
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            _log4net.Info(" Http GET request All Record requsted");

            return Ok(db.Books.ToList());
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            _log4net.Info(" Http GET request by Id requested id = " + id);

            return db.Books.Find(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public string Post([FromBody] Book obj)
        {
            _log4net.Info(" Http Post request");

            db.Books.Add(obj);
            db.SaveChanges();
            return "Record Added";

        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Book obj)
        {
            _log4net.Info("PUT ---Update Request");

            Book book = db.Books.Find(id);
            book.Name = obj.Name;
            book.Author = obj.Author;
            book.Price = obj.Price;
            book.IsAvailable = obj.IsAvailable;

            db.SaveChanges();
            return "Updated";
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
            {
                _log4net.Info(" Delete requsted");

                db.Books.Remove(book);
                db.SaveChanges();
                return "Removed";
            }
            return "Not Found";
        }
    }
}
