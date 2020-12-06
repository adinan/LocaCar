using LocaCar.Business.Models.Validations.Documentos;
using FluentValidation;

namespace LocaCar.Business.Models.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(f => f.Cpf)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(f => f.Cpf.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("O campo {PropertyName} precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(f => CpfValidacao.Validar(f.Cpf)).Equal(true)
                .WithMessage("O Cpf fornecido é inválido.");
             
        }
    }
}