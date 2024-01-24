﻿// <auto-generated />
using FotoBlog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FotoBlog.Data.Migrations
{
    [DbContext(typeof(UygulamaDBContext))]
    [Migration("20240124064333_Ilk")]
    partial class Ilk
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FotoBlog.Data.Gonderi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Baslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResimYolu")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Gonderiler");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Baslik = "Batarken güneş ardında tepelerin, veda vakti geldi teletabilerin..",
                            ResimYolu = "gunbatimi.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Baslik = "Derin mavilerde, su altı masalı coşkuyla dans eder, Balıkların ışıltılı gölgesi, gizemli bir dünyayı örer..",
                            ResimYolu = "sualti.jpg"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
