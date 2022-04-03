using FluentValidation;
using Gazin.Dominio.Models;

namespace Gazin.Dominio.Validations
{
    public class NiveisValidation :AbstractValidator<Niveis>
    {
        public NiveisValidation()
        {
            RuleFor(n => n.Nivel)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");           
        }
    }
}
