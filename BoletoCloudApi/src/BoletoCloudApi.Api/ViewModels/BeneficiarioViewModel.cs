namespace BoletoCloudApi.Api.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// view model para representar beneficiario.
    /// </summary>
    public class BeneficiarioViewModel
    {
        /// <summary>
        /// Identificador único do boleto.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome do beneficiário.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        /// <summary>
        /// Cadastro de Pessoa na Receita Federal: CPF ou CNPJ do beneficiário.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Cprf { get; set; }

        /// <summary>
        /// Cep do beneficiário.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cep { get; set; }

        /// <summary>
        /// Estado do beneficiário.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Uf { get; set; }

        /// <summary>
        /// Localidade do beneficiário.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Localidade { get; set; }

        /// <summary>
        /// Bairro do beneficiário.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Bairro { get; set; }

        /// <summary>
        /// Logradouro do beneficiário.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Logradouro { get; set; }

        /// <summary>
        /// Numero do logradouro do beneficiário.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Numero { get; set; }

        /// <summary>
        /// Boleto id associado ao boleto.
        /// </summary>
        public Guid BoletoId { get; set; }
    }
}
