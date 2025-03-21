﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBooks.Data;

#nullable disable

namespace MyBooks.Migrations
{
    [DbContext(typeof(MyBooksDbContext))]
    partial class MyBooksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("MyBooks.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("Isbn")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("AuthorId");

                    b.ToTable("Author", (string)null);
                });

            modelBuilder.Entity("MyBooks.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Author")
                        .HasColumnType("longtext");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Isbn")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Published")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("MyBooks.Models.Book", b =>
                {
                    b.HasOne("MyBooks.Models.Author", null)
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBooks.Models.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
