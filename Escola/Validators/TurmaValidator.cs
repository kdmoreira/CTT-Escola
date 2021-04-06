using Escola.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.API.Validators
{
    public class TurmaValidator : AbstractValidator<Turma>
    {
        public TurmaValidator()
        {
            RuleFor(x => x.Curso).NotEmpty().NotNull()
                .WithMessage("Curso não deve estar vazio.");
            RuleFor(x => x.Edicao).NotEmpty().NotNull()
                .WithMessage("Edição não deve estar vazia.");
        }
    }
}
