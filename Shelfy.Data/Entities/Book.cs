using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shelfy.Data.Entities
{
    public class Book
    {
        [Key]
        public int BookId {get; set;}

        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public Author Author {get; set;}
        public string Title {get; set;}
        public string ISBN {get; set;}
        public int GenreId {get; set;}
        
         [ForeignKey(nameof(GenreId))]
        public virtual Genre Genre {get; set;}
        public DateTime PublishedDate {get; set;}
        public DateTime ObtainedDate {get; set;}
        public string Status {get; set;}
        public string Summary {get; set;}
    }
}