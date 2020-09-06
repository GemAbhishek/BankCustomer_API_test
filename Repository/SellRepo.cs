using BookRepositoryDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRepositoryDemo.Repository
{
    public class SellRepo : ISellRepo
    {
        ApplicationDbContext db;
        public SellRepo(ApplicationDbContext _db)
        {
            db = _db;
        }


        public int Update(int id, int data)
        {
            if (db != null)
            {
                SellRecord book = db.SellRecords.Where(x => x.Id == id).FirstOrDefault();
                if (book != null)
                {
                    book.SellQty += data;
                    book.date = DateTime.Now;
                    db.SaveChanges();
                    return 1;
                }
                return 0;
            }
            return 0;
        }
    }
}
