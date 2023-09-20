using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shelfy.Models.BookModels
{
    public class BookCreate
    {
        
        [Required]
        public string Title {get; set;}

        public int AuthorId {get; set;}

        [Required]
        public string ISBN {get; set;}
        public int GenreId {get; set;}
        
        [Required]
        public DateTime PublishedDate {get; set;}
        [Required]
        public DateTime ObtainedDate {get; set;}

        [Required]
        public string Status {get; set;}
        [Required]
        public string Summary {get; set;}
    }
}