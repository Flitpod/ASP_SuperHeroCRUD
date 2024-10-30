﻿// <auto-generated />
using M3_SuperHeroCRUD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace M3_SuperHeroCRUD.Migrations
{
    [DbContext(typeof(SuperHeroDbContext))]
    [Migration("20241030095435_DbInit")]
    partial class DbInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("M3_SuperHeroCRUD.Models.SuperHero", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("HeroSide")
                        .HasColumnType("int");

                    b.Property<bool>("IsAlien")
                        .HasColumnType("bit");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("SuperHeroes");
                });
#pragma warning restore 612, 618
        }
    }
}
