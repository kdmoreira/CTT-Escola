using Escola.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola.API.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().NotNull()
                .WithMessage("Nome não deve estar vazio.");
            RuleFor(x => x.Perfil).NotEmpty().NotNull()
                .WithMessage("Perfil não deve estar vazio.");
            RuleFor(x => x.Senha).NotEmpty().NotNull().Length(5, 10)
                .WithMessage("Senha não deve estar vazia.");
        }
    }
}
