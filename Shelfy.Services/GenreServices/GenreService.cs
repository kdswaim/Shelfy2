using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shelfy.Data.Context;
using Shelfy.Data.Entities;
using Shelfy.Models.GenreModels;

namespace Shelfy.Services.GenreServices
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenreService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> CreateGenre(GenreCreate model)
        {
            var genre = _mapper.Map<Genre>(model);
            
            await _context.Genres.AddAsync(genre);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if(genre is null)
            return false;

            _context.Genres.Remove(genre);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<GenreDetail> GetGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            var genreDetail = _mapper.Map<GenreDetail>(genre);
            return genreDetail;
        }

        public async Task<List<GenreListItem>> GetGenre()
        {
            var genreListItems = _mapper.Map<List<GenreListItem>>(await _context.Genres.ToListAsync());
            return genreListItems;
        }

        public async Task<bool> UpdateGenre(GenreEdit model)
        {
            var genre = await _context.Genres.SingleOrDefaultAsync(x => x.Id == model.Id);
            if (genre is null) return false;
                
                genre.Id = model.Id;
                genre.GenreName = model.GenreName;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}