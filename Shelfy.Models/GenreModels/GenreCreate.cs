using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shelfy.Models.GenreModels
{
    public class GenreCreate
    {
        [Required]
        [MaxLength(200)]
        public string GenreName {get; set;}
    }
}