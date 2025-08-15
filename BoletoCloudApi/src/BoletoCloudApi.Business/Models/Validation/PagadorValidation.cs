namespace BoletoCloudApi.Business.Models.Validation
{
    using FluentValidation;

    /// <summary>
    /// Fornece regras de validação para a entidade <see cref="Pagador"/> utilizando FluentValidation.
    /// Garante que os campos obrigatórios estejam presentes e que os valores atendam aos requisitos de negócio.
    /// </summary>
    public class PagadorValidation : AbstractValidator<Pagador>
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="PagadorValidation"/>.
        /// Define as regras de validação para as propriedades do <see cref="Pagador"/>:
        /// <list type="bullet">
        /// <item><description><c>Nome</c>: Obrigatório, entre 1 e 100 caracteres.</description></item>
        /// <item><description><c>CpfCnpj</c>: Obrigatório, entre 11 e 14 caracteres.</description></item>
        /// <item><description><c>Cep</c>: Obrigatório, exatamente 8 caracteres.</description></item>
        /// <item><description><c>Uf</c>: Obrigatório, exatamente 2 caracteres.</description></item>
        /// <item><description><c>Localidade</c>: Obrigatório.</description></item>
        /// <item><description><c>Bairro</c>: Obrigatório, entre 1 e 50 caracteres.</description></item>
        /// <item><description><c>Logradouro</c>: Obrigatório, entre 1 e 100 caracteres.</description></item>
        /// <item><description><c>Numero</c>: Obrigatório, entre 1 e 20 caracteres.</description></item>
        /// </list>
        /// </summary>
        public PagadorValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome do pagador não pode ser vazio.")
                .Length(1, 100).WithMessage("O nome do pagador deve ter entre 1 e 100 caracteres.");

            RuleFor(p => p.CpfCnpj)
                .NotEmpty().WithMessage("O CPF/CNPJ do pagador não pode ser vazio.")
                .Length(11, 14).WithMessage("O CPF/CNPJ do pagador deve ter entre 11 e 14 caracteres.");

            RuleFor(p => p.Cep).NotEmpty().WithMessage("O CEP do pagador não pode ser vazio.")
                .Length(8).WithMessage("O CEP do pagador deve ter 8 caracteres.");

            RuleFor(p => p.Uf).NotEmpty().WithMessage("A UF do pagador não pode ser vazia.").Length(2)
                .WithMessage("A UF do pagador deve ter 2 caracteres.");

            RuleFor(p => p.Localidade)
                .NotEmpty()
                .WithMessage("A localidade do pagador não pode ser vazia.");

            RuleFor(p => p.Bairro)
                .NotEmpty().WithMessage("O bairro do pagador não pode ser vazio.")
                .Length(1, 50).WithMessage("O bairro do pagador deve ter entre 1 e 50 caracteres.");

            RuleFor(p => p.Logradouro).NotEmpty().WithMessage("O logradouro do pagador não pode ser vazio.")
                .Length(1, 100).WithMessage("O logradouro do pagador deve ter entre 1 e 100 caracteres.");

            RuleFor(p => p.Numero).NotEmpty().WithMessage("O número do pagador não pode ser vazio.").Length(1, 20)
                .WithMessage("O número do pagador deve ter entre 1 e 20 caracteres.");
        }
    }
}
