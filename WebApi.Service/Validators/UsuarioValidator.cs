using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Domain.Entities;

namespace WebApi.Service.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("por favor insira com o nome.")
                .NotNull().WithMessage("por favor entre com o nome.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("por favor insira o email.")
                .NotNull().WithMessage("por favor entre com o email.");

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("por favor insira com o senha.")
                .NotNull().WithMessage("por favor entre com o senha.");

        }
        


    }
}
