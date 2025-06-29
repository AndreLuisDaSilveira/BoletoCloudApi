using System.ComponentModel.DataAnnotations;

namespace BoletoCloudApi.Api.ViewModels
{
    public class BoletoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Documento { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Sequencial { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime Vencimento { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime Emissao { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }
        
        public string? Token { get; set; }
        public DateTime CriadoEm { get; set; }

        public ContaBancariaViewModel? Conta { get; set; }
        public BeneficiarioViewModel? Beneficiario { get; set; }
        public PagadorViewModel? Pagador { get; set; }
    }

    public class ContaBancariaViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Numero { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Sequencial { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Banco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Agencia { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Carteira { get; set; }
        public Guid BoletoId { get; set; }
    }

    public class BeneficiarioViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Cprf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Localidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Numero { get; set; }
        public Guid BoletoId { get; set; }
    }

    public class PagadorViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Localidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Numero { get; set; }
        public Guid BoletoId { get; set; }

    }
}
