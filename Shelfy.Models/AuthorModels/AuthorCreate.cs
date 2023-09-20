using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shelfy.Models.AuthorModels
{
    public class AuthorCreate
    {
        [Required]
        public int AuthorId {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Biography {get; set;}
        [Required]
        public string Website {get; set;}
    }
}