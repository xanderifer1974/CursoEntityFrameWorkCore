﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Switch.Infra.Data.Context;

namespace Switch.Infra.Data.Migrations
{
    [DbContext(typeof(SwitchContext))]
    [Migration("20190823173114_AddConfiguracaoPostagem")]
    partial class AddConfiguracaoPostagem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Switch.Domain.Entities.Identificacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Numero");

                    b.Property<int>("TipoDocumento");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Identificacao");
                });

            modelBuilder.Entity("Switch.Domain.Entities.Postagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataPublicacao");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Postagens");
                });

            modelBuilder.Entity("Switch.Domain.Entities.StatusRelacionamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("StatusRelacionamento");
                });

            modelBuilder.Entity("Switch.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<int>("Sexo");

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("UrlFoto")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Switch.Domain.Entities.Identificacao", b =>
                {
                    b.HasOne("Switch.Domain.Entities.Usuario", "Usuario")
                        .WithOne("Identificacao")
                        .HasForeignKey("Switch.Domain.Entities.Identificacao", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Switch.Domain.Entities.Postagem", b =>
                {
                    b.HasOne("Switch.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Postagens")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
