using Bookstore.Core;
using Bookstore.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService service)
        {
            _bookService = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return new JsonResult(await _bookService.GetBooksAsync());
        }
        [HttpGet("{id}", Name = "GetBook")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _bookService.GetBookAsync(id);
            if (book is null)
            {
                return NotFound();
            }
            return new JsonResult(book);
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            if (!ModelState.IsValid 
                || book is null)
            {
                return new JsonResult(book);
            }
            await _bookService.AddBookAsync(book);
            return new CreatedAtRouteResult("GetBook", new { id = book.Id }, book);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            var newBook = _bookService.GetBookAsync(book.Id);
            if (newBook is null)
            {
                return new JsonResult(book);
            }
            await _bookService.UpdateBookAsync(book);
            return new JsonResult(book);
        }
    }
}
