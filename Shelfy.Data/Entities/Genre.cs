using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelfy.Data.Entities
{
    public class Genre
    {
        public int Id {get; set;}
        public string GenreName {get; set;}
        public virtual ICollection<Book> Books {get; set;} = new List<Book>();    
    }
}