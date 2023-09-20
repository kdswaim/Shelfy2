using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shelfy.Data.Entities;

namespace Shelfy.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) { }

        public DbSet<Genre> Genres {get; set;}
        public DbSet<Book> Books {get; set;}
        public DbSet<Author> Authors {get; set;}
    }
}