using FluentValidation;
using Gazin.Dominio.Models;

namespace Gazin.Dominio.Validations
{
    public class DesenvolvedorValidation : AbstractValidator<Desenvolvedor>
    {
        public DesenvolvedorValidation()
        {
            RuleFor(d => d.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(d => d.NivelId)
                .GreaterThan(0)
                .WithMessage("O código nível precisa ser preenchido");

            RuleFor(d => d.Sexo)
                .NotEmpty()
                .WithMessage("Campo Sexo precisar ser preenchido");
        }
    }
}
