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
        private readonly ApplicationDbContext db;

        public BookController(ApplicationDbContext _db)
        {
            db = _db;
        }

        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return db.Books.ToList();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public string Post([FromBody] Book obj)
        {
            db.Books.Add(obj);
            db.SaveChanges();
            return "Record Added";

        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Book obj)
        {
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
                db.Books.Remove(book);
                db.SaveChanges();
                return "Removed";
            }
            return "Not Found";
        }
    }
}
