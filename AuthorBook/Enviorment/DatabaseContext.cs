using AuthorBook.domain;
using Microsoft.EntityFrameworkCore;

namespace AuthorBook.NewFolder
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DatabaseContext(){}
        public DbSet<author> Authors { get; set; }
        public DbSet<book> Books { get; set; }
    }
}
