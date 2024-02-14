using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BulkyBook.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Addtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

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
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1L, 1, "Action" },
                    { 2L, 3, "Scifi" },
                    { 3L, 2, "History" },
                    { 4L, 4, "Literary Fiction" },
                    { 5L, 6, "Non Fiction" },
                    { 6L, 6, "Science and Popular Science" },
                    { 7L, 7, "Travel" },
                    { 8L, 9, "Humor" },
                    { 9L, 8, "Religion and Spirituality" },
                    { 10L, 10, "Crafts and Hobbies" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1L, "Robert Wilson", 2L, "Book is about Adventures", "12321", 20.5, 19.5, 15.5, 17.5, "Action" },
                    { 2L, "Alice Johnson", 3L, "Exciting journey into the unknown", "23432", 22.75, 21.25, 17.25, 19.75, "Adventure" },
                    { 3L, "John Smith", 2L, "Unraveling secrets and enigmas", "34543", 18.989999999999998, 17.489999999999998, 14.49, 15.99, "Mystery" },
                    { 4L, "Emily Brown", 5L, "Magical realms and mythical creatures", "45654", 25.989999999999998, 24.489999999999998, 21.489999999999998, 22.989999999999998, "Fantasy" },
                    { 5L, "David Jones", 4L, "Exploring futuristic worlds and technology", "56765", 29.989999999999998, 28.489999999999998, 25.489999999999998, 26.989999999999998, "Science Fiction" },
                    { 6L, "Sophia Lee", 3L, "Heartwarming love stories", "67876", 15.949999999999999, 14.449999999999999, 11.449999999999999, 12.949999999999999, "Romance" },
                    { 7L, "Michael White", 2L, "Nerve-wracking suspense and excitement", "78987", 21.5, 20.0, 17.0, 18.5, "Thriller" },
                    { 8L, "Elizabeth Taylor", 6L, "Journeys through historical events and periods", "89098", 27.75, 26.25, 23.25, 24.75, "Historical Fiction" },
                    { 9L, "Thomas Harris", 3L, "Terrifying tales of fear and horror", "90109", 19.989999999999998, 18.489999999999998, 15.49, 16.989999999999998, "Horror" },
                    { 10L, "Anna Miller", 8L, "Inspirational life stories", "01210", 16.5, 15.0, 12.0, 13.5, "Biography" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
