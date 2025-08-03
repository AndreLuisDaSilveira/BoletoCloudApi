namespace BoletoCloudApi.Business.Models.Validation
{
    using FluentValidation;

    /// <summary>
    /// Fornece regras de validação para a entidade <see cref="Beneficiario"/> utilizando FluentValidation.
    /// Garante que os campos obrigatórios estejam presentes e que os valores atendam aos requisitos de negócio.
    /// </summary>
    public class BeneficiarioValidation : AbstractValidator<Beneficiario>
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="BeneficiarioValidation"/>.
        /// Define as regras de validação para as propriedades do <see cref="Beneficiario"/>:
        /// <list type="bullet">
        /// <item><description><c>Nome</c>: Obrigatório, entre 1 e 100 caracteres.</description></item>
        /// <item><description><c>Cprf</c>: Obrigatório, entre 11 e 14 caracteres.</description></item>
        /// <item><description><c>Cep</c>: Obrigatório, exatamente 8 caracteres.</description></item>
        /// <item><description><c>Uf</c>: Obrigatório, exatamente 2 caracteres.</description></item>
        /// <item><description><c>Localidade</c>: Obrigatório, entre 1 e 50 caracteres.</description></item>
        /// <item><description><c>Bairro</c>: Obrigatório, entre 1 e 50 caracteres.</description></item>
        /// <item><description><c>Logradouro</c>: Obrigatório, entre 1 e 100 caracteres.</description></item>
        /// <item><description><c>Numero</c>: Obrigatório, entre 1 e 20 caracteres.</description></item>
        /// </list>
        /// </summary>
        public BeneficiarioValidation()
        {
            RuleFor(b => b.Nome)
                .NotEmpty().WithMessage("O nome do beneficiário não pode ser vazio.")
                .Length(1, 100).WithMessage("O nome do beneficiário deve ter entre 1 e 100 caracteres.");

            RuleFor(b => b.Cprf)
                .NotEmpty().WithMessage("O CPF/CNPJ do beneficiário não pode ser vazio.")
                .Length(11, 14).WithMessage("O CPF/CNPJ do beneficiário deve ter entre 11 e 14 caracteres.");

            RuleFor(b => b.Cep).NotEmpty().WithMessage("O CEP do beneficiário não pode ser vazio.")
                .Length(8).WithMessage("O CEP do beneficiário deve ter 8 caracteres.");

            RuleFor(b => b.Uf).NotEmpty().WithMessage("A UF do beneficiário não pode ser vazia.")
                .Length(2).WithMessage("A UF do beneficiário deve ter 2 caracteres.");

            RuleFor(b => b.Localidade).NotEmpty().WithMessage("A localidade do beneficiário não pode ser vazia.")
                .Length(1, 50).WithMessage("A localidade do beneficiário deve ter entre 1 e 50 caracteres.");

            RuleFor(b => b.Bairro).NotEmpty().WithMessage("O bairro do beneficiário não pode ser vazio.").Length(1, 50)
                .WithMessage("O bairro do beneficiário deve ter entre 1 e 50 caracteres.");

            RuleFor(b => b.Logradouro)
                .NotEmpty().WithMessage("O logradouro do beneficiário não pode ser vazio.").Length(1, 100)
                .WithMessage("O logradouro do beneficiário deve ter entre 1 e 100 caracteres.");

            RuleFor(b => b.Numero)
                .NotEmpty().WithMessage("O número do beneficiário não pode ser vazio.").Length(1, 20)
                .WithMessage("O número do beneficiário deve ter entre 1 e 20 caracteres."); 
        }
    }
}
