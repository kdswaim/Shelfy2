using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shelfy.Models.GenreModels;

namespace Shelfy.Services.GenreServices
{
    public interface IGenreService
    {
        Task<bool> CreateGenre(GenreCreate model);
        Task<bool> UpdateGenre(GenreEdit model);
        Task<bool>DeleteGenre(int id);
        Task<GenreDetail> GetGenre(int id);
        Task<List<GenreListItem>> GetGenre();
    }
}