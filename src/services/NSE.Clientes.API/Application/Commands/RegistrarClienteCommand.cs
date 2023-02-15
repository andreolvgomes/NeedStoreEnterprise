using FluentValidation;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using NSE.Core.Messages;
using System;

namespace NSE.Clientes.API.Application.Commands
{
    public class RegistrarClienteCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cfp { get; set; }

        public RegistrarClienteCommand(Guid id, string nome, string email, string cfp)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cfp = cfp;
        }

        public override bool EhValido()
        {
            ValidationResult = new RegistrarClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RegistrarClienteValidation : AbstractValidator<RegistrarClienteCommand>
    {
        public RegistrarClienteValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("Informe o Nome do Cliente");

            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do Cliente inválido");

            RuleFor(c => c.Cfp)
                .Must(TerCpfValido)
                .WithMessage("O CPF informado não é válido");

            RuleFor(c => c.Email)
               .Must(TerEmailValido)
               .WithMessage("O e-mail informado não é válido");
        }

        protected static bool TerCpfValido(string cfp)
        {
            return Core.DomainObjects.Cpf.Validar(cfp);
        }

        protected static bool TerEmailValido(string email)
        {
            return Core.DomainObjects.Email.Validar(email);
        }
    }
}