using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shelfy.Models.BookModels;

namespace Shelfy.Services.BookServices
{
    public interface IBookService
    {
        Task<bool> CreateBook(BookCreate model);
        Task<bool> UpdateBook(BookEdit model);
        Task<bool> DeleteBook(int id);
        Task<BookDetail> GetBook(int id);
        Task<List<BookListItem>> GetBook();
    }
}