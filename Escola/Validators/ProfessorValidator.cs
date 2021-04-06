using Escola.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.API.Validators
{
    public class ProfessorValidator : AbstractValidator<Professor>
    {
        public ProfessorValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().NotNull()
                .WithMessage("Nome não deve estar vazio.");
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull()
                .WithMessage("Informe um email válido.");
            RuleFor(x => x.Ativo).NotEmpty().NotNull()
                .WithMessage("Deve informar se está ativo ou inativo.");
        }
    }
}
