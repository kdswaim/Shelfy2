using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shelfy.Models.AuthorModels;
using Shelfy.Models.GenreModels;

namespace Shelfy.Models.BookModels
{
    public class BookListItem
    {
        public int BookId {get; set;}
        public string Title {get; set;}
        public AuthorListItem Author { get; set; }
        public GenreListItem Genre { get; set; }
    }
}