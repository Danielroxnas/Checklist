﻿// <auto-generated />
using System;
using Checklist.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Checklist.Migrations
{
    [DbContext(typeof(ChecklistContext))]
    partial class ChecklistContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Checklist.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Checklist.Models.Grocery", b =>
                {
                    b.Property<Guid>("GroceryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GroceryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroceryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Groceries");
                });

            modelBuilder.Entity("Checklist.Models.GroceryShoppingList", b =>
                {
                    b.Property<Guid>("GroceryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShoppingListId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroceryId", "ShoppingListId");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("GroceryShoppingList");
                });

            modelBuilder.Entity("Checklist.Models.ShoppingList", b =>
                {
                    b.Property<Guid>("ShoppingListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ShoppingListName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ShoppingListId");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingList");
                });

            modelBuilder.Entity("Checklist.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Checklist.Models.Grocery", b =>
                {
                    b.HasOne("Checklist.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Checklist.Models.GroceryShoppingList", b =>
                {
                    b.HasOne("Checklist.Models.Grocery", "Grocery")
                        .WithMany("GroceryShoppingList")
                        .HasForeignKey("GroceryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Checklist.Models.ShoppingList", "ShoppingList")
                        .WithMany("GroceryShoppingList")
                        .HasForeignKey("ShoppingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Checklist.Models.ShoppingList", b =>
                {
                    b.HasOne("Checklist.Models.User", "User")
                        .WithMany("Checklists")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
