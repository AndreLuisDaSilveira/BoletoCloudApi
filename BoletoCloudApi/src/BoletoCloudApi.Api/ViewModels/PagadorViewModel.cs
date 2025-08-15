namespace BoletoCloudApi.Api.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// view model para representar pagador.
    /// </summary>
    public class PagadorViewModel
    {
        /// <summary>
        /// Identificador único do boleto.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome associado ao pagador.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        /// <summary>
        /// Cadastro de Pessoa na Receita Federal: CPF ou CNPJ associado ao pagador.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string CpfCnpj { get; set; }

        /// <summary>
        /// Cep do pagador.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cep { get; set; }

        /// <summary>
        /// Estado do pagador.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Uf { get; set; }

        /// <summary>
        /// Localidade do pagador.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Localidade { get; set; }

        /// <summary>
        /// Bairro do pagador.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Bairro { get; set; }

        /// <summary>
        /// Logradouro do pagdor.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Logradouro { get; set; }

        /// <summary>
        /// Número do logradouro do pagador.
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Numero { get; set; }

        /// <summary>
        /// Boleto id associado ao boleto.
        /// </summary>
        public Guid BoletoId { get; set; }
    }
}
