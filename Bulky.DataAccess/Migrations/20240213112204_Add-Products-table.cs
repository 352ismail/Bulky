using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BulkyBook.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1L, "Robert Wilson", "Book is about Adventures", "12321", 20.5, 19.5, 15.5, 17.5, "Action" },
                    { 2L, "Alice Johnson", "Exciting journey into the unknown", "23432", 22.75, 21.25, 17.25, 19.75, "Adventure" },
                    { 3L, "John Smith", "Unraveling secrets and enigmas", "34543", 18.989999999999998, 17.489999999999998, 14.49, 15.99, "Mystery" },
                    { 4L, "Emily Brown", "Magical realms and mythical creatures", "45654", 25.989999999999998, 24.489999999999998, 21.489999999999998, 22.989999999999998, "Fantasy" },
                    { 5L, "David Jones", "Exploring futuristic worlds and technology", "56765", 29.989999999999998, 28.489999999999998, 25.489999999999998, 26.989999999999998, "Science Fiction" },
                    { 6L, "Sophia Lee", "Heartwarming love stories", "67876", 15.949999999999999, 14.449999999999999, 11.449999999999999, 12.949999999999999, "Romance" },
                    { 7L, "Michael White", "Nerve-wracking suspense and excitement", "78987", 21.5, 20.0, 17.0, 18.5, "Thriller" },
                    { 8L, "Elizabeth Taylor", "Journeys through historical events and periods", "89098", 27.75, 26.25, 23.25, 24.75, "Historical Fiction" },
                    { 9L, "Thomas Harris", "Terrifying tales of fear and horror", "90109", 19.989999999999998, 18.489999999999998, 15.49, 16.989999999999998, "Horror" },
                    { 10L, "Anna Miller", "Inspirational life stories", "01210", 16.5, 15.0, 12.0, 13.5, "Biography" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
