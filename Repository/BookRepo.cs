using BookRepositoryDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRepositoryDemo.Repository
{
    public class BookRepo : IBookRepo
    {
        ApplicationDbContext db;
        public BookRepo(ApplicationDbContext _db)
        {
            db = _db;
        }
        public int AddDetail(Book data)
        {
            //return 1 if done
            if (db != null)
            {
                db.Books.Add(data);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int DeleteDetail(int Id)
        {
            if (db != null)
            {
                Book book = db.Books.FirstOrDefault(x => x.Id == Id);

                if (book != null)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                    return 1;
                }
                return 0;
            }
            return 0;
        }

        public Book GetDetail(int? Id)
        {
            if (db != null)
            {
                return (db.Books.Where(x => x.Id == Id)).FirstOrDefault();
            }
            return null;
        }

        public List<Book> GetDetails()
        {
            if (db != null)
            {
                return db.Books.ToList();
            }
            return null;
        }

        public int UpdateDetail(int id, Book data)
        {
            if (db != null)
            {
                try
                {
                    data.Id = id;
                    db.Books.Update(data);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
            return 0;
        }
    }
}
