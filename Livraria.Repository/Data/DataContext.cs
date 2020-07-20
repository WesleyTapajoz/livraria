using Livraria.Domain;
using Livraria.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Repository.Data
{
    public class DataContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<InstituicaoEnsino> InstituicoesEnsino { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            }
              );


            modelBuilder.Entity<Emprestimo>(userRole =>
            {
                userRole.HasKey(em => new { em.EmprestimoId });

                userRole.HasOne(ur => ur.Livro)
                    .WithMany(r => r.Emprestimos)
                    .HasForeignKey(ur => ur.LivroId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.Emprestimos)
                    .HasForeignKey(ur => ur.Id)
                    .IsRequired();
            }
             );

          
            modelBuilder.Seed();

        }

    }
}