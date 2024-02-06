using BulkyBook.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Category> Category { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): 
            base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Scifi", DisplayOrder = 3 },
                new Category { Id = 3, Name = "History", DisplayOrder = 2 },
                new Category { Id = 4, Name = "Literary Fiction", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Non Fiction", DisplayOrder = 6},
                new Category { Id = 6, Name = "Science and Popular Science", DisplayOrder = 6 },
                new Category { Id = 7, Name = "Travel", DisplayOrder = 7 },
                new Category { Id = 8, Name = "Humor", DisplayOrder = 9 },
                new Category { Id = 9, Name = "Religion and Spirituality", DisplayOrder = 8 },
                new Category { Id = 10, Name = "Crafts and Hobbies", DisplayOrder = 10 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
