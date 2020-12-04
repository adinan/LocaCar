using FluentValidation;

namespace LocaCar.Business.Models.Validations
{
    public class VeiculoValidation : AbstractValidator<Veiculo>
    {
        public VeiculoValidation()
        {
            RuleFor(c => c.Modelo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            RuleFor(c => c.Marca)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            RuleFor(c => c.Placa)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
          
            RuleFor(c => c.AnoModelo).ExclusiveBetween(1000,9999).WithMessage("O campo {PropertyName} está invalido");
            RuleFor(c => c.AnoFabricacao).ExclusiveBetween(1000, 9999).WithMessage("O campo {PropertyName} está invalido");

        }
    }
}