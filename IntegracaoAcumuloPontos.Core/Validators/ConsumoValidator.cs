using FluentValidation;
using IntegracaoAcumuloPontos.Application.DTOs;

namespace IntegracaoAcumuloPontos.Application.Validators
{
    public class ConsumoDtoValidator : AbstractValidator<ConsumoDto>
    {
        public ConsumoDtoValidator()
        {
            RuleFor(c => c.IdPessoa)
                .GreaterThan(0)
                .WithMessage("No Consumo deve informar a pessoa que a realizou.");

            RuleFor(c => c.ValorTotal)
                .GreaterThan(0)
                .WithMessage("O ValorTotal deve ser maior que zero.");

            RuleFor(c => c.DataConsumo)
                .NotEmpty()
                .WithMessage("A Data de Consumo é obrigatória.");
        }
    }
}
