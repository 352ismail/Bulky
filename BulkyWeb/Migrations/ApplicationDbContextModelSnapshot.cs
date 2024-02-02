﻿// <auto-generated />
using BulkyWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BulkyWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BulkyWeb.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DisplayOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2L,
                            DisplayOrder = 3,
                            Name = "Scifi"
                        },
                        new
                        {
                            Id = 3L,
                            DisplayOrder = 2,
                            Name = "History"
                        },
                        new
                        {
                            Id = 4L,
                            DisplayOrder = 4,
                            Name = "Literary Fiction"
                        },
                        new
                        {
                            Id = 5L,
                            DisplayOrder = 6,
                            Name = "Non Fiction"
                        },
                        new
                        {
                            Id = 6L,
                            DisplayOrder = 6,
                            Name = "Science and Popular Science"
                        },
                        new
                        {
                            Id = 7L,
                            DisplayOrder = 7,
                            Name = "Travel"
                        },
                        new
                        {
                            Id = 8L,
                            DisplayOrder = 9,
                            Name = "Humor"
                        },
                        new
                        {
                            Id = 9L,
                            DisplayOrder = 8,
                            Name = "Religion and Spirituality"
                        },
                        new
                        {
                            Id = 10L,
                            DisplayOrder = 10,
                            Name = "Crafts and Hobbies"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
