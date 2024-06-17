using AppAlunos_BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAlunos_BackEnd.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Aluno> Alunos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>().HasData(
            new Aluno
            {
                Id = 1,
                Nome = "João Victor Araujo",
                Email = "joaozinho@gmail.com",
                Idade = 23
            },
            new Aluno
            {
                Id = 2,
                Nome = "Joao Victor Garcia",
                Email = "garciazinho@gmail.com",
                Idade=22
            }
        );
    }
}
