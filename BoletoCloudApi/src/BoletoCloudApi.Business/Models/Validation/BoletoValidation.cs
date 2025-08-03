namespace BoletoCloudApi.Business.Models.Validation
{
    using FluentValidation;

    /// <summary>
    /// Fornece regras de validação para a entidade <see cref="Boleto"/> utilizando FluentValidation.
    /// Garante que os campos obrigatórios estejam presentes e que os valores atendam aos requisitos de negócio.
    /// </summary>
    public class BoletoValidation : AbstractValidator<Boleto>
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="BoletoValidation"/>.
        /// Define as regras de validação para as propriedades do <see cref="Boleto"/>:
        /// <list type="bullet">
        /// <item><description><c>Numero</c>: Obrigatório, entre 1 e 20 caracteres.</description></item>
        /// <item><description><c>Documento</c>: Obrigatório, entre 1 e 50 caracteres.</description></item>
        /// <item><description><c>Sequencial</c>: Deve ser maior que zero.</description></item>
        /// <item><description><c>Valor</c>: Deve ser maior que zero.</description></item>
        /// <item><description><c>Vencimento</c>: Deve ser uma data futura.</description></item>
        /// <item><description><c>Emissao</c>: Não pode ser uma data futura.</description></item>
        /// </list>
        /// </summary>
        public BoletoValidation()
        {
            RuleFor(b => b.Numero)
                .NotEmpty().WithMessage("O número do boleto não pode ser vazio.")
                .Length(1, 20).WithMessage("O número do boleto deve ter entre 1 e 20 caracteres.");

            RuleFor(b => b.Documento)
                .NotEmpty().WithMessage("O documento do boleto não pode ser vazio.")
                .Length(1, 50).WithMessage("O documento do boleto deve ter entre 1 e 50 caracteres.");

            RuleFor(b => b.Sequencial)
                .GreaterThan(0).WithMessage("O sequencial do boleto deve ser maior que zero.");

            RuleFor(b => b.Valor)
                .GreaterThan(0).WithMessage("O valor do boleto deve ser maior que zero.");

            RuleFor(b => b.Vencimento)
                .GreaterThan(DateTime.Now).WithMessage("A data de vencimento deve ser futura.");

            RuleFor(b => b.Emissao)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de emissão não pode ser futura.");
        }
    }
}
