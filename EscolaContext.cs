using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscolaDomain;
using Microsoft.EntityFrameworkCore;
namespace ADOLab
{
    class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar relacionamento Aluno <-> Matricula
            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Aluno)
                .WithMany(a => a.Matriculas)
                .HasForeignKey(m => m.AlunoId);

            // Configurar relacionamento Disciplina <-> Matricula
            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Disciplina)
                .WithMany(d => d.Matriculas)
                .HasForeignKey(m => m.DisciplinaId);

            // Configurar relacionamento Professor <-> Disciplina
            modelBuilder.Entity<Disciplina>()
                .HasOne(d => d.Professor)
                .WithMany(p => p.Disciplinas)
                .HasForeignKey(d => d.ProfessorId);
        }
    }
}
