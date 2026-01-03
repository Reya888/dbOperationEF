using Microsoft.EntityFrameworkCore;

namespace dbOperationEFCORE.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency() { Id = 1, Title = "INR", Description = "Indian Curr" },
                new Currency() { Id = 2, Title = "Dollar", Description = "US Curr" },
                new Currency() { Id = 3, Title = "EURO", Description = "EU Curr" }
                );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = 1, Description = "English", Name = "S-Chand" },
                new Language() { Id = 2, Description = "Maths", Name = "Shakespere"}
                );
        }



        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}
