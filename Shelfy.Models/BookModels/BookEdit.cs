using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelfy.Models.BookModels
{
    public class BookEdit
    {
        public int BookId {get; set;}
        public int AuthorId {get; set;}
        public string Title {get; set;}
        public string ISBN {get; set;}
        public int GenreId { get; set; }
      //  public IEnumerable<SelectListItem> GenreList { get; set; }
        public DateTime PublishedDate {get; set;}
        public DateTime ObtainedDate {get; set;}
        public string Status {get; set;}
        public string Summary {get; set;}
    }
}