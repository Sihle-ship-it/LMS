using LibraryManagementApi.Models;
using MySql.Data.EntityFramework;
using System.Data.Entity;

namespace LibraryManagementApi.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("LmsDbConnection")
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example of configuring a relationship
            modelBuilder.Entity<Book>()
                .HasRequired(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorID);
        }
    }
}