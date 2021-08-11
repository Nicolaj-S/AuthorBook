using AuthorBook.domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.NewFolder
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DatabaseContext(){}
        public DbSet<author> authors { get; set; }
        public DbSet<book> books { get; set; }
    }
}
