using BookRepositoryDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRepositoryDemo.Repository
{
    public class SellRecordRepo : ISellRecordRepo
    {
        ApplicationDbContext db;
        public SellRecordRepo(ApplicationDbContext _db)
        {
            db = _db;
        }
        public int AddDetail(SellRecord data)
        {
            if (db != null)
            {
                db.SellRecords.Add(data);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int DeleteDetail(int Id)
        {
            if (db != null)
            {
                SellRecord book = db.SellRecords.FirstOrDefault(x => x.Id == Id);

                if (book != null)
                {
                    db.SellRecords.Remove(book);
                    db.SaveChanges();
                    return 1;
                }
                return 0;
            }
            return 0;
        }

        public SellRecord GetDetail(int? Id)
        {
            if (db != null)
            {
                return (db.SellRecords.Where(x => x.Id == Id)).FirstOrDefault();
            }
            return null;
        }

        public List<SellRecord> GetDetails()
        {
            if (db != null)
            {
                return db.SellRecords.ToList();
            }

            return null;
        }

        public int UpdateDetail(int id, SellRecord data)
        {
            if (db != null)
            {
                try
                {
                    data.Id = id;
                    db.SellRecords.Update(data);
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
