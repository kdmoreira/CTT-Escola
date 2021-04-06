using Escola.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.API.Validators
{
    public class AlunoValidator : AbstractValidator<Aluno>
    {
        public AlunoValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().NotNull()
                .WithMessage("Nome não deve estar vazio.");
            RuleFor(x => x.Cpf).NotEmpty().NotNull().Length(11)
                .WithMessage("CPF não deve estar vazio e deve ter 11 dígitos.");
            RuleFor(x => x.Ativo).NotEmpty()
                .WithMessage("Deve informar se está ativo ou não.");
        }
    }
}
