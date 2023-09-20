using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shelfy.Models.BookModels;
using Shelfy.Services.AuthorServices;
using Shelfy.Services.BookServices;
using Shelfy.Services.GenreServices;

namespace Shelfy.MVC.Controllers
{
    public class BookController : Controller
    {
       private IBookService _bookService;
       private IAuthorService _authorService;
       private IGenreService _genreService;
        public BookController(IBookService bookService, IAuthorService authorService, IGenreService genreService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _genreService = genreService;
        }

        public async Task<IActionResult>Index()
        {
            return View(await _bookService.GetBook());
        }

        public async Task<IActionResult> Details(int id)
      {
        var book = await _bookService.GetBook(id);
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
      }
      public async Task<IActionResult> Create() 
      {
        return View();
      } 

      public async Task<IActionResult> CreateBook(BookCreate book)
      {
        if (!ModelState.IsValid)
        {
            return View(ModelState);
        }
        if (await _bookService.CreateBook(book))
        return RedirectToAction(nameof(Index));
        else
        {
            return View(ModelState);
        }
      }

            public async Task<IActionResult> Edit(int id)
      {
        var book = await _bookService.GetBook(id);
        var bookEdit = new BookEdit
        {
            BookId = book.BookId,
            AuthorId = book.Author.AuthorId,
            GenreId = book.Genre.Id,
            Title = book.Title,
            ISBN = book.ISBN,
            PublishedDate = book.PublishedDate,
            ObtainedDate = book.ObtainedDate,
            Status = book.Status,
            Summary = book.Summary
            
        };
        return View(bookEdit);
      }

      public async Task<IActionResult> BookEdit(BookEdit model)
      {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if(await _bookService.UpdateBook(model))
            return RedirectToAction(nameof(Index));
            else
            return View(model);
      }

      public async Task<IActionResult> Delete(int? id)
      {
        var book = await _bookService.GetBook(id.Value);
        return View(book);
      }

     // [HttpPost] 
     // [ValidateAntiForgeryToken]
     // [Route("DeleteBook/{id:int}")]
      public async Task<IActionResult> DeleteBook(int BookId)
      {
        var isSuccessful = await _bookService.DeleteBook(BookId);
        if (isSuccessful)
        return RedirectToAction(nameof(Index));
        else
        return UnprocessableEntity();
      }
    }
}