using System.Runtime;

namespace BoletoCloudApi.Business.Models
{
    public class Boleto : Entity
    {
        public string Numero { get; set; }
        public string Documento { get; set; }
        public int Sequencial { get; set; }
        public decimal Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime Emissao { get; set; }
        public string Titulo { get; set; }
        public string? Token { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;

        public ContaBancaria? Conta { get; set; }
        public Beneficiario? Beneficiario { get; set; }
        public Pagador? Pagador { get; set; }
    }

    public class ContaBancaria : Entity
    {
        public Guid BoletoId { get; set; }
        public string Numero { get; set; }
        public int Sequencial { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string Carteira { get; set; }

        public Boleto Boleto { get; set; }

    }

    public class Beneficiario: Entity
    {
        public Guid BoletoId { get; set; }
        public string Nome { get; set; }
        public string Cprf { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Localidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public Boleto Boleto { get; set; }
    }

    public class Pagador : Entity
    {
        public Guid BoletoId { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Localidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public Boleto Boleto { get; set; }
    }
}
