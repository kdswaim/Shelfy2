using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelfy.Models.AuthorModels
{
    public class AuthorEdit
    {
        public int AuthorId {get; set;}
        public string Name {get; set;}
        public string Biography {get; set;}
        public string Website {get; set;}
    }
}