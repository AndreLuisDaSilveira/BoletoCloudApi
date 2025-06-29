using FluentValidation;

namespace BoletoCloudApi.Business.Models.Validation
{
    public class BoletoValidation :  AbstractValidator<Boleto>
    {
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

    public class ContaBancariaValidation : AbstractValidator<ContaBancaria>
    {
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

    public class BeneficiarioValidation : AbstractValidator<Beneficiario>
    {
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

    public class PagadorValidation : AbstractValidator<Pagador>
    {
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
