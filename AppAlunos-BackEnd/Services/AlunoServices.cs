using AppAlunos_BackEnd.Context;
using AppAlunos_BackEnd.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace AppAlunos_BackEnd.Services
{
    public class AlunoServices : IAlunoService
    {
        private readonly AppDbContext _context;

        public AlunoServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            try
            {
                return await _context.Alunos.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Aluno>> GetAlunoByNome(string nome)
        {
            IEnumerable<Aluno> alunos;

            if (!string.IsNullOrEmpty(nome))
            {
                alunos = _context.Alunos.Where(a => a.Nome == nome);
            } else
            {
                alunos = await GetAlunos();
            }
            return alunos;
        }
        public async Task<Aluno> GetAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            return aluno;
        }
        public async Task CreateAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAluno(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAluno(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }
    }
}
