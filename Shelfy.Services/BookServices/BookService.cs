using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shelfy.Data.Context;
using Shelfy.Data.Entities;
using Shelfy.Models.BookModels;

namespace Shelfy.Services.BookServices
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> CreateBook(BookCreate model)
        {
            var book = _mapper.Map<Book>(model);
            await _context.Books.AddAsync(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if(book is null) return false;

            _context.Books.Remove(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<BookDetail> GetBook(int id)
        {
            var book = await _context.Books.Include(b => b.Author).Include(b => b.Genre).SingleOrDefaultAsync(x => x.BookId == id);
            var bookDetail = _mapper.Map<BookDetail>(book);
            return bookDetail;
        }

        public async Task<List<BookListItem>> GetBook()
        {
            var books = await _context.Books.Include(b => b.Author).Include(b => b.Genre).ToListAsync();
            var bookListItems = _mapper.Map<List<BookListItem>>(books);
            return bookListItems;
        }

        public async Task<bool> UpdateBook(BookEdit model)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.BookId == model.BookId);
            if (book is null) return false;

            book.Title = model.Title;
            book.BookId = model.BookId;
            book.Summary = model.Summary;
            book.AuthorId = model.AuthorId;
            book.GenreId = model.GenreId;
            book.ISBN = model.ISBN;
            book.PublishedDate = model.PublishedDate;
            book.ObtainedDate = model.ObtainedDate;
            book.Status = model.Status;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}