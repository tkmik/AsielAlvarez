using Bookstore.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _dbContext;
        public BookService(AppDbContext db)
        {
            _dbContext = db;
        }
        public Book AddBook(Book book)
        {
            _dbContext.Add(book);
            _dbContext.SaveChanges();
            return book;
        }
        public async Task<Book> AddBookAsync(Book book)
        {
            await _dbContext.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public void DeleteBook(int id)
        {
            var book = GetBook(id);
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
        public async Task DeleteBookAsync(int id)
        {
            var book = await GetBookAsync(id);
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();            
        }

        public Book GetBook(int id)
        {
            return _dbContext.Books
                .Include(t=>t.Category)
                .Include(t=>t.Author)
                .FirstOrDefault(u=>u.Id == id);
        }
        public async Task<Book> GetBookAsync(int id)
        {
            return await _dbContext.Books
                .Include(t => t.Category)
                .Include(t => t.Author)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public List<Book> GetBooks()
        {
            return _dbContext.Books
                .Include(t=>t.Category)
                .Include(t=>t.Author)
                .ToList();
        }
        public async Task<List<Book>> GetBooksAsync()
        {
            return await _dbContext.Books
                .Include(t => t.Category)
                .Include(t => t.Author)
                .ToListAsync();
        }

        public Book UpdateBook(Book book)
        {
            var newBook = GetBook(book.Id);
            newBook = book;
            _dbContext.Books.Update(newBook);
            _dbContext.SaveChanges();
            return newBook;
        }
        public async Task<Book> UpdateBookAsync(Book book)
        {            
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }
    }
}
