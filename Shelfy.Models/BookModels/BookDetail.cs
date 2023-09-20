using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shelfy.Models.AuthorModels;
using Shelfy.Models.GenreModels;

namespace Shelfy.Models.BookModels
{
    public class BookDetail
    {
        public int BookId {get; set;}
        public string Title {get; set;}
        public string ISBN {get; set;}

        public AuthorListItem Author { get; set; }
        public GenreListItem Genre { get; set; }
        public DateTime PublishedDate {get; set;}
        public DateTime ObtainedDate {get; set;}
        public string Status {get; set;}
        public string Summary {get; set;}
    }
}