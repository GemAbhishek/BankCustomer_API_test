using BookRepositoryDemo.Model;
using System.Collections.Generic;

namespace BookRepositoryDemo.Repository
{
    public interface ISellRecordRepo
    {
        int AddDetail(SellRecord data);
        int DeleteDetail(int Id);
        SellRecord GetDetail(int? Id);
        List<SellRecord> GetDetails();
        int UpdateDetail(int id, SellRecord data);
    }
}