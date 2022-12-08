﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Fk_Id_Seller")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("Fk_Id_Seller");

                    b.ToTable("products");
                });

            modelBuilder.Entity("WebApplication1.Entities.Seller", b =>
                {
                    b.Property<int>("Id_Seller")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Allias")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id_Seller");

                    b.ToTable("sellers");
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.HasOne("WebApplication1.Entities.Seller", "Fk_")
                        .WithMany("Products")
                        .HasForeignKey("Fk_Id_Seller")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fk_");
                });

            modelBuilder.Entity("WebApplication1.Entities.Seller", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
