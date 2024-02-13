using BulkyBook.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using BulkyBook.Models.Models.Products;

namespace BulkyBook.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }
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
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Action", ISBN = "12321" , Author= "Robert Wilson", Description ="Book is about Adventures", ListPrice = 20.5,Price=19.5,Price50=17.5,Price100=15.5},
                new Product { Id = 2, Title = "Adventure", ISBN = "23432", Author = "Alice Johnson", Description = "Exciting journey into the unknown", ListPrice = 22.75, Price = 21.25, Price50 = 19.75, Price100 = 17.25 },
                new Product { Id = 3, Title = "Mystery", ISBN = "34543", Author = "John Smith", Description = "Unraveling secrets and enigmas", ListPrice = 18.99, Price = 17.49, Price50 = 15.99, Price100 = 14.49 },
                new Product { Id = 4, Title = "Fantasy", ISBN = "45654", Author = "Emily Brown", Description = "Magical realms and mythical creatures", ListPrice = 25.99, Price = 24.49, Price50 = 22.99, Price100 = 21.49 },
                new Product { Id = 5, Title = "Science Fiction", ISBN = "56765", Author = "David Jones", Description = "Exploring futuristic worlds and technology", ListPrice = 29.99, Price = 28.49, Price50 = 26.99, Price100 = 25.49 },
                new Product { Id = 6, Title = "Romance", ISBN = "67876", Author = "Sophia Lee", Description = "Heartwarming love stories", ListPrice = 15.95, Price = 14.45, Price50 = 12.95, Price100 = 11.45 },
                new Product { Id = 7, Title = "Thriller", ISBN = "78987", Author = "Michael White", Description = "Nerve-wracking suspense and excitement", ListPrice = 21.5, Price = 20.0, Price50 = 18.5, Price100 = 17.0 },
                new Product { Id = 8, Title = "Historical Fiction", ISBN = "89098", Author = "Elizabeth Taylor", Description = "Journeys through historical events and periods", ListPrice = 27.75, Price = 26.25, Price50 = 24.75, Price100 = 23.25 },
                new Product { Id = 9, Title = "Horror", ISBN = "90109", Author = "Thomas Harris", Description = "Terrifying tales of fear and horror", ListPrice = 19.99, Price = 18.49, Price50 = 16.99, Price100 = 15.49 },
                new Product { Id = 10, Title = "Biography", ISBN = "01210", Author = "Anna Miller", Description = "Inspirational life stories", ListPrice = 16.5, Price = 15.0, Price50 = 13.5, Price100 = 12.0 }

                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
