using System;
using System.Collections.Generic;

namespace EscolaDomain
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }

        // Relação 1:N com Matricula
        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();

        // Construtor sem parâmetros obrigatório para EF Core
        public Aluno() { }

        public Aluno(string nome, int idade, string email, DateTime dataNascimento)
        {
            Nome = nome;
            Idade = idade;
            Email = email;
            DataNascimento = dataNascimento;
        }
    }

    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Relação 1:N com Disciplina
        public ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

        public Professor() { }

        public Professor(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }

    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        // Chave estrangeira para Professor
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; } = null!;

        // Relação 1:N com Matricula
        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();

        public Disciplina() { }

        public Disciplina(string nome, int professorId)
        {
            Nome = nome;
            ProfessorId = professorId;
        }
    }

    public class Matricula
    {
        public int Id { get; set; }

        // Chave estrangeira para Aluno
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; } = null!;

        // Chave estrangeira para Disciplina
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; } = null!;

        public DateTime DataMatricula { get; set; } = DateTime.Now;

        public Matricula() { }

        public Matricula(int alunoId, int disciplinaId)
        {
            AlunoId = alunoId;
            DisciplinaId = disciplinaId;
        }
    }
}
