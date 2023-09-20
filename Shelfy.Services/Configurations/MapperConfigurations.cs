using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shelfy.Data.Entities;
using Shelfy.Models.AuthorModels;
using Shelfy.Models.BookModels;
using Shelfy.Models.GenreModels;

namespace Shelfy.Services.Configurations
{
    public class MapperConfigurations : Profile
    {
        public MapperConfigurations()
        {
            CreateMap<Author, AuthorCreate>().ReverseMap();
            CreateMap<Author, AuthorEdit>().ReverseMap();
            CreateMap<Author, AuthorDetail>().ReverseMap();
            CreateMap<Author, AuthorListItem>().ReverseMap();

            CreateMap<Book, BookCreate>().ReverseMap();
            CreateMap<Book, BookEdit>().ReverseMap();
            CreateMap<Book, BookDetail>().ReverseMap();
            CreateMap<Book, BookListItem>().ReverseMap();

            CreateMap<Genre, GenreCreate>().ReverseMap();
            CreateMap<Genre, GenreEdit>().ReverseMap();
            CreateMap<Genre, GenreDetail>().ReverseMap();
            CreateMap<Genre, GenreListItem>().ReverseMap();
        }
    }
}