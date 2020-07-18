﻿// <auto-generated />
using System;
using Livraria.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Livraria.Repository.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Livraria.Domain.Entity.Emprestimo", b =>
                {
                    b.Property<int>("EmprestimoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EmprestimoId");

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("Livraria.Domain.Entity.InstituicaoEnsino", b =>
                {
                    b.Property<int>("InstituicaoEnsinoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CPNJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstituicaoEnsinoId");

                    b.ToTable("InstituicoesEnsino");

                    b.HasData(
                        new
                        {
                            InstituicaoEnsinoId = 1,
                            Ativo = false,
                            CPNJ = "02.402.105/0001-00",
                            Endereco = "Boa Esperança, Cuiabá",
                            Nome = "UFMT",
                            Telefone = "65 9999-9999"
                        });
                });

            modelBuilder.Entity("Livraria.Domain.Entity.InstituicaoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("InstituicaoUsuarioId")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int?>("InstituicaoEnsinoId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id", "InstituicaoUsuarioId");

                    b.HasIndex("InstituicaoEnsinoId");

                    b.HasIndex("UserId");

                    b.ToTable("InstituicaoUsuario");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            InstituicaoUsuarioId = 1,
                            Ativo = false
                        },
                        new
                        {
                            Id = 4,
                            InstituicaoUsuarioId = 1,
                            Ativo = false
                        });
                });

            modelBuilder.Entity("Livraria.Domain.Entity.Livro", b =>
                {
                    b.Property<int>("LivroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Autor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sinopse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LivroId");

                    b.ToTable("Livros");

                    b.HasData(
                        new
                        {
                            LivroId = 1,
                            Ativo = false,
                            Autor = "Shakespeare",
                            Genero = "Romance",
                            ImagemURL = "",
                            Sinopse = "Romeu e Julieta é a primeira das grandes tragédias de William Shakespeare...",
                            Titulo = "Romeu e Julieta"
                        },
                        new
                        {
                            LivroId = 2,
                            Ativo = false,
                            Autor = "Shakespeare",
                            Genero = "Romance",
                            ImagemURL = "",
                            Sinopse = "A obsessão de uma vingança onde a dúvida e o desespero concentrados nos monólogos do príncipe Hamlet adquirem uma impressionante dimensão trágica...",
                            Titulo = "Hamlet"
                        },
                        new
                        {
                            LivroId = 3,
                            Ativo = false,
                            Autor = "Machado de Assis",
                            Genero = "Romance",
                            ImagemURL = "",
                            Sinopse = "Mas criando Capitu, a espantosa menina de 'olhos oblíquos e dissimulados', de 'olhos de ressaca'...",
                            Titulo = "Dom Casmurro"
                        },
                        new
                        {
                            LivroId = 4,
                            Ativo = false,
                            Autor = "Machado de Assis",
                            Genero = "Romance",
                            ImagemURL = "",
                            Sinopse = "A libertação dos escravos e a Proclamação da República formam o pano de fundo para a história de irmãos gêmeos rivais...",
                            Titulo = "Esaú e Jacó"
                        });
                });

            modelBuilder.Entity("Livraria.Domain.Entity.Reserva", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataReserva")
                        .HasColumnType("datetime2");

                    b.Property<int>("LivroId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ReservaId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Livraria.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Livraria.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            Ativo = true,
                            CPF = "019.266.931-16",
                            ConcurrencyStamp = "8e8caf4f-bd1b-4918-939a-be505e5d8a01",
                            Email = "shakespeare@outlook.com",
                            EmailConfirmed = false,
                            Endereco = "Stratford-upon-Avon, Reino Unido",
                            FullName = "shakespeare",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            Telefone = "65 99999-9999",
                            TwoFactorEnabled = false,
                            UserName = "Shakespeare"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            Ativo = true,
                            CPF = "019.266.931-17",
                            ConcurrencyStamp = "eb6a5ed5-32b8-42b8-96bf-7cbb335dbea4",
                            Email = "machadosssis@outlook.com",
                            EmailConfirmed = false,
                            Endereco = "Rio de Janeiro, Brasil",
                            FullName = "Machado de Assis",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            Telefone = "65 99999-9999",
                            TwoFactorEnabled = false,
                            UserName = "machadoassis"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            Ativo = true,
                            CPF = "019.266.931-17",
                            ConcurrencyStamp = "8f8e1169-7e33-412f-9c3f-f859c9358bff",
                            Email = "wesley@outlook.com",
                            EmailConfirmed = false,
                            Endereco = "Cuiabá, Brasil",
                            FullName = "Wesley Tapajoz",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            Telefone = "65 99999-9999",
                            TwoFactorEnabled = false,
                            UserName = "wesley"
                        },
                        new
                        {
                            Id = 4,
                            AccessFailedCount = 0,
                            Ativo = true,
                            CPF = "019.266.931-17",
                            ConcurrencyStamp = "08a2ddf0-510a-4079-986b-ab9ac301cd7e",
                            Email = "tapajoz@outlook.com",
                            EmailConfirmed = false,
                            Endereco = "Várzea Grande, Brasil",
                            FullName = "Wesley Douglas",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            Telefone = "65 99999-9999",
                            TwoFactorEnabled = false,
                            UserName = "douglas"
                        });
                });

            modelBuilder.Entity("Livraria.Domain.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Livraria.Domain.Entity.InstituicaoUsuario", b =>
                {
                    b.HasOne("Livraria.Domain.Entity.InstituicaoEnsino", "InstituicaoEnsino")
                        .WithMany()
                        .HasForeignKey("InstituicaoEnsinoId");

                    b.HasOne("Livraria.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Livraria.Domain.UserRole", b =>
                {
                    b.HasOne("Livraria.Domain.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Livraria.Domain.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Livraria.Domain.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Livraria.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Livraria.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Livraria.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}