namespace BoletoCloudApi.Business.Models.Validation
{
    using FluentValidation;

    /// <summary>
    /// Fornece regras de validação para a entidade <see cref="ContaBancaria"/> utilizando FluentValidation.
    /// Garante que os campos obrigatórios estejam presentes e que os valores atendam aos requisitos de negócio.
    /// </summary>
    public class ContaBancariaValidation : AbstractValidator<ContaBancaria>
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ContaBancariaValidation"/>.
        /// Define as regras de validação para as propriedades do <see cref="ContaBancaria"/>:
        /// <list type="bullet">
        /// <item><description><c>Numero</c>: Obrigatório, entre 1 e 20 caracteres.</description></item>
        /// <item><description><c>Banco</c>: Obrigatório, entre 1 e 50 caracteres.</description></item>
        /// <item><description><c>Agencia</c>: Obrigatório, entre 1 e 20 caracteres.</description></item>
        /// <item><description><c>Carteira</c>: Obrigatório, entre 1 e 20 caracteres.</description></item>
        /// </list>
        /// </summary>
        public ContaBancariaValidation()
        {
            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("O número da conta não pode ser vazio.")
                .Length(1, 20).WithMessage("O número da conta deve ter entre 1 e 20 caracteres.");

            RuleFor(c => c.Banco)
                .NotEmpty().WithMessage("O banco não pode ser vazio.")
                .Length(1, 50).WithMessage("O banco deve ter entre 1 e 50 caracteres.");

            RuleFor(c => c.Agencia).NotEmpty().WithMessage("A agência não pode ser vazia.")
                .Length(1, 20).WithMessage("A agência deve ter entre 1 e 20 caracteres.");

            RuleFor(c => c.Carteira)
                .NotEmpty().WithMessage("A carteira não pode ser vazia.")
                .Length(1, 20).WithMessage("A carteira deve ter entre 1 e 20 caracteres.");
        }
    }
}
