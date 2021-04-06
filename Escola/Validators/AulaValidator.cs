using Escola.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.API.Validators
{
    public class AulaValidator : AbstractValidator<Aula>
    {
        public AulaValidator()
        {
            RuleFor(x => x.Assunto).NotEmpty().NotNull()
                .WithMessage("Assunto deve ser informado.");
        }
    }
}
