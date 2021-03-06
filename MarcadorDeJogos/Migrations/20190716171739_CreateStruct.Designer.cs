﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MarcadorDeJogos.Models;

namespace MarcadorDeJogos.Migrations
{
    [DbContext(typeof(MarcadorDeJogosContext))]
    [Migration("20190716171739_CreateStruct")]
    partial class CreateStruct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MarcadorDeJogos.Models.Jogadores", b =>
                {
                    b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
                    b.Property<string>("Nome");
                    b.ToTable("Jogadores");
                });

            modelBuilder.Entity("MarcadorDeJogos.Models.Jogos", b =>
                {
                    b.Property<int>("Id").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
                    b.Property<string>("NomeJogo");
                    b.ToTable("Jogos");
                });
#pragma warning restore 612, 618
        }
    }
}
