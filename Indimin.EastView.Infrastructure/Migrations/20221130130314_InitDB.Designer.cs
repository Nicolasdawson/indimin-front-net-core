﻿// <auto-generated />
using System;
using Indimin.EastView.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Indimin.EastView.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221130130314_InitDB")]
    partial class InitDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Indimin.EastView.Domain.Entities.Cuidadano", b =>
                {
                    b.Property<int>("CuidadanoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CuidadanoId"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CuidadanoId");

                    b.ToTable("CUIDADANO", (string)null);
                });

            modelBuilder.Entity("Indimin.EastView.Domain.Entities.Tarea", b =>
                {
                    b.Property<int>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TareaId"));

                    b.Property<int>("CuidadanoId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("TareaId");

                    b.HasIndex("CuidadanoId");

                    b.ToTable("TAREA", (string)null);
                });

            modelBuilder.Entity("Indimin.EastView.Domain.Entities.Tarea", b =>
                {
                    b.HasOne("Indimin.EastView.Domain.Entities.Cuidadano", "Cuidadano")
                        .WithMany("Tareas")
                        .HasForeignKey("CuidadanoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuidadano");
                });

            modelBuilder.Entity("Indimin.EastView.Domain.Entities.Cuidadano", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
