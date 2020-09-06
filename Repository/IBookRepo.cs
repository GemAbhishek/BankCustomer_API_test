using BookRepositoryDemo.Model;
using System.Collections.Generic;

namespace BookRepositoryDemo.Repository
{
    public interface IBookRepo
    {
        int AddDetail(Book data);
        int DeleteDetail(int Id);
        Book GetDetail(int? Id);
        List<Book> GetDetails();
        int UpdateDetail(int id, Book data);
    }
}