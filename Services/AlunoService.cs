using AlunoGestao.Models;

namespace AlunoGestao.Services;

public static class AlunoService
{
    static List<Aluno> Alunos { get; }
    static int nextId = 3;
    static AlunoService()
    {
        Alunos = new List<Aluno>
        {
            new Aluno { Id = 1, Nome = "Arnaldo", RegistroAcademico = "Matriculado",Periodo = 5 ,Curso = "Matematica", Status = "Aprovado" },
            new Aluno { Id = 2, Nome = "Veggie", RegistroAcademico = "Matriculado",Periodo = 4 ,Curso = "|Fisica", Status = "Reprovado" }
        };
    }

    public static List<Aluno> GetAll() => Alunos;

    public static Aluno? Get(int id) => Alunos.FirstOrDefault(p => p.Id == id);

    public static void Add(Aluno aluno)
    {
        aluno.Id = nextId++;
        Alunos.Add(aluno);
    }

    public static void Delete(int id)
    {
        var aluno = Get(id);
        if(aluno is null)
            return;

        Alunos.Remove(aluno);
    }

    public static void Update(Aluno aluno)
    {
        var index = Alunos.FindIndex(p => p.Id == aluno.Id);
        if(index == -1)
            return;

        Alunos[index] = aluno;
    }
}