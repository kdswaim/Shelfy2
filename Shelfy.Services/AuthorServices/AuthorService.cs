using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shelfy.Data.Context;
using Shelfy.Data.Entities;
using Shelfy.Models.AuthorModels;

namespace Shelfy.Services.AuthorServices
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> CreateAuthor(AuthorCreate model)
        {
            var author = _mapper.Map<Author>(model);
            await _context.Authors.AddAsync(author);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author is null) return false;

            _context.Authors.Remove(author);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<AuthorDetail> GetAuthor(int id)
        {
            var author = await _context.Authors.SingleOrDefaultAsync(x => x.AuthorId == id);
            if (author is null) return new AuthorDetail{};
            return _mapper.Map<AuthorDetail>(author);
        }

        public async Task<List<AuthorListItem>> GetAuthor()
        {
            var authors = await _context.Authors.ToListAsync();
            var authorListItems = _mapper.Map<List<AuthorListItem>>(authors);
            return authorListItems;
        }

        public async Task<bool> UpdateAuthor(AuthorEdit model)
        {
            var author = await _context.Authors.SingleOrDefaultAsync(x => x.AuthorId == model.AuthorId);
            if (author is null) return false;
            
            author.Name = model.Name;
            author.Biography = model.Biography;
            author.Website = model.Website;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}