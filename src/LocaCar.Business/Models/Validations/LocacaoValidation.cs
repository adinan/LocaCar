using FluentValidation;
using System;

namespace LocaCar.Business.Models.Validations
{
    public class LocacaoValidation : AbstractValidator<Locacao>
    {
        public LocacaoValidation()
        {
            RuleFor(c => c.DataInicio).Must(BeAValidDate)
                .WithMessage("O campo {PropertyName} precisa ser fornecido");
            
            RuleFor(c => c.DataFim).Must(BeAValidDate)
                            .WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(df => df.DataFim).GreaterThanOrEqualTo(di => di.DataInicio)
                            .WithMessage("O campo {PropertyName} precisa ser maior ou igual ao campo Data Inicio");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}