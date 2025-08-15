namespace BoletoCloudApi.Business.Models
{
    /// <summary>
    /// Representa o beneficiário de um boleto, contendo informações pessoais e de endereço
    /// necessárias para identificação e relacionamento com o boleto.
    /// </summary>
    public class Beneficiario : Entity
    {
        /// <summary>
        /// Identificador do boleto associado ao beneficiário.
        /// </summary>
        public Guid BoletoId { get; set; }

        /// <summary>
        /// Nome completo do beneficiário.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// CPF ou CNPJ do beneficiário.
        /// </summary>
        public string Cprf { get; set; }

        /// <summary>
        /// CEP do endereço do beneficiário.
        /// </summary>
        public string Cep { get; set; }

        /// <summary>
        /// Unidade Federativa (UF) do beneficiário.
        /// </summary>
        public string Uf { get; set; }

        /// <summary>
        /// Cidade ou localidade do beneficiário.
        /// </summary>
        public string Localidade { get; set; }

        /// <summary>
        /// Bairro do beneficiário.
        /// </summary>
        public string Bairro { get; set; }

        /// <summary>
        /// Logradouro do beneficiário (rua, avenida, etc).
        /// </summary>
        public string Logradouro { get; set; }

        /// <summary>
        /// Número do endereço do beneficiário.
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Referência ao boleto associado a este beneficiário.
        /// </summary>
        public Boleto Boleto { get; set; }
    }
}
