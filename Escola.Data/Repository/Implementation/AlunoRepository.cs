using Escola.Data.Interface;
using Escola.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Escola.Data.Repository
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        private readonly Guid _guid;
        public AlunoRepository(Contexto contexto) : base(contexto)
        {
            _guid = Guid.NewGuid();
        }

        // Busca todos os alunos, podendo buscar por CPF ou contendo nome
        public List<Aluno> SelecionarAlunos(string nome)
        {
            List<Aluno> alunos = _contexto.Aluno
                .Include(x => x.TurmaAluno).OrderBy(x => x.Nome)
                .ToList();

            if (nome != null)
            {
                return alunos.Where(a => a.Nome.Contains(nome)).ToList();
                
            }
            return alunos;
        }

        public Aluno SelecionarPorCpf(string cpf)
        {
            return _contexto.Aluno
                .Include(x => x.TurmaAluno).OrderBy(x => x.Nome)
                .FirstOrDefault(a => a.Cpf.Equals(cpf));

        }

        public string IncluirAluno(Aluno aluno)
        {
            if (PermiteCadastro(aluno))
            {
                base.Incluir(aluno);
                return "Cadastro feito com sucesso!";
            }
            return "Aluno já cadastrado.";
        }

        public string AlterarAluno(Aluno aluno)
        {
            if (PermiteTurma(aluno))
            {
                base.Alterar(aluno);
                return "Alteração realizada.";
            }
            return "Aluno já frequenta um curso.";
        }

        public bool PermiteCadastro(Aluno aluno)
        {
            Aluno alunoQuery = _contexto.Aluno.FirstOrDefault(x => x.Cpf == aluno.Cpf);
            if (alunoQuery == null)
            {
                return true;
            }
            return false;
        }

        public bool PermiteTurma(Aluno aluno)
        {
            if (aluno.Ativo)
            {
                return false;
            }
            return true;
        }
    }
}
