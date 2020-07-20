using Livraria.Domain;
using Livraria.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Repository.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<InstituicaoEnsino>().HasData(
           new InstituicaoEnsino
           {
               InstituicaoEnsinoId = 1,
               Nome = "UFMT",
               CPNJ = "02.402.105/0001-00",
               Endereco = "Boa Esperança, Cuiabá",
               Telefone = "65 9999-9999",
               Ativo =  true
           });

           modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    CPF = "019.266.931-16",
                    UserName = "Shakespeare",
                    Endereco = "Stratford-upon-Avon, Reino Unido",
                    Email = "shakespeare@outlook.com",
                    Ativo =  true,
                    Telefone = "65 99999-9999",
                    FullName = "shakespeare"
                },
                new User
                {
                    Id = 2,
                    CPF = "019.266.931-17",
                    UserName = "machadoassis",
                    Endereco = "Rio de Janeiro, Brasil",
                    Email = "machadosssis@outlook.com",
                    Ativo = true,
                    Telefone = "65 99999-9999",
                    FullName = "Machado de Assis"

                },
                new User
                {
                    Id = 3,
                    CPF = "019.266.931-17",
                    UserName = "wesley",
                    Endereco = "Cuiabá, Brasil",
                    Email = "wesley@outlook.com",
                    Ativo = true,
                    Telefone = "65 99999-9999",
                    FullName = "Wesley Tapajoz"

                },
                new User
                {
                    Id = 4,
                    CPF = "019.266.931-17",
                    UserName = "douglas",
                    Endereco = "Várzea Grande, Brasil",
                    Email = "tapajoz@outlook.com",
                    Ativo = true,
                    Telefone = "65 99999-9999",
                    FullName = "Wesley Douglas"

                }
            );

            modelBuilder.Entity<InstituicaoUsuario>().HasData(
             new InstituicaoUsuario
             {
                 InstituicaoUsuarioId = 1,
                 Id = 3
             },
              new InstituicaoUsuario
              {
                  InstituicaoUsuarioId = 1,
                  Id = 4
              }
             );

            modelBuilder.Entity<Livro>().HasData(
               new Livro
               {
                   LivroId = 1,
                   Genero = "Romance",
                   Titulo = "Romeu e Julieta",
                   Sinopse = "Romeu e Julieta é a primeira das grandes tragédias de William Shakespeare...",
                   ImagemURL = "romeuejulieta.jpg",
                   Autor = "Shakespeare",
                   Ativo =  true
               },
                new Livro
                {
                    LivroId = 2,
                    Genero = "Romance",
                    Titulo = "Hamlet",
                    Sinopse = "A obsessão de uma vingança onde a dúvida e o desespero concentrados nos monólogos do príncipe Hamlet adquirem uma impressionante dimensão trágica...",
                    ImagemURL = "hamlet.jpg",
                    Autor = "Shakespeare",
                    Ativo =  true
                },
                new Livro
                {
                    LivroId = 3,
                    Genero = "Romance",
                    Titulo = "Dom Casmurro",
                    Sinopse = "Mas criando Capitu, a espantosa menina de 'olhos oblíquos e dissimulados', de 'olhos de ressaca'...",
                    ImagemURL = "domcasmurro.jpg",
                    Autor = "Machado de Assis",
                    Ativo =  true
                },
                new Livro
                {
                    LivroId = 4,
                    Genero = "Romance",
                    Titulo = "Esaú e Jacó",
                    Sinopse = "A libertação dos escravos e a Proclamação da República formam o pano de fundo para a história de irmãos gêmeos rivais...",
                    ImagemURL = "esauejaco.jpg",
                    Autor = "Machado de Assis",
                    Ativo =  true
                }
            );
        }
    }
}
