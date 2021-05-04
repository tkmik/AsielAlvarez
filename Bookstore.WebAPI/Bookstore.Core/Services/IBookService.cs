using Bookstore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public interface IBookService
    {
        List<Book> GetBooks();
        Book AddBook(Book book);
        Task<Book> AddBookAsync(Book book);
        Task<List<Book>> GetBooksAsync();
        Book GetBook(int id);
        Task<Book> GetBookAsync(int id);
        void DeleteBook(int id);
        Task DeleteBookAsync(int id);
        Book UpdateBook(Book book);
        Task<Book> UpdateBookAsync(Book book);
    }
}
