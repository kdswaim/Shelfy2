using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shelfy.Models.AuthorModels;

namespace Shelfy.Services.AuthorServices
{
    public interface IAuthorService
    {
        Task<bool> CreateAuthor(AuthorCreate model);
        Task<bool> UpdateAuthor(AuthorEdit model);
        Task<bool> DeleteAuthor(int id);
        Task<AuthorDetail> GetAuthor(int id);
        Task<List<AuthorListItem>> GetAuthor();
    }
}