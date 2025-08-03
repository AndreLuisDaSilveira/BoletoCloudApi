namespace BoletoCloudApi.Business.Models
{
    /// <summary>
    /// Representa o pagador de um boleto, contendo informações pessoais e de endereço
    /// necessárias para identificação e relacionamento com o boleto.
    /// </summary>
    public class Pagador : Entity
    {
        /// <summary>
        /// Identificador do boleto associado ao pagador.
        /// </summary>
        public Guid BoletoId { get; set; }

        /// <summary>
        /// Nome completo do pagador.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// CPF ou CNPJ do pagador.
        /// </summary>
        public string CpfCnpj { get; set; }

        /// <summary>
        /// CEP do endereço do pagador.
        /// </summary>
        public string Cep { get; set; }

        /// <summary>
        /// Unidade Federativa (UF) do pagador.
        /// </summary>
        public string Uf { get; set; }

        /// <summary>
        /// Cidade ou localidade do pagador.
        /// </summary>
        public string Localidade { get; set; }

        /// <summary>
        /// Bairro do pagador.
        /// </summary>
        public string Bairro { get; set; }

        /// <summary>
        /// Logradouro do pagador (rua, avenida, etc).
        /// </summary>
        public string Logradouro { get; set; }

        /// <summary>
        /// Número do endereço do pagador.
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Referência ao boleto associado a este pagador.
        /// </summary>
        public Boleto Boleto { get; set; }
    }
}
