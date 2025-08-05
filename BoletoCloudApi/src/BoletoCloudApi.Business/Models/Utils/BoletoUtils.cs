namespace BoletoCloudApi.Business.Models.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Classe utilitária para operações relacionadas a boletos, como montagem de parâmetros e aplicação de máscaras.
    /// </summary>
    internal static class BoletoUtils
    {
        /// <summary>
        /// Monta o dicionário de parâmetros necessários para a requisição de geração de boleto na API BoletoCloud.
        /// Extrai e formata os dados do objeto <see cref="Boleto"/> e suas entidades relacionadas (beneficiário, conta bancária e pagador).
        /// </summary>
        /// <param name="boleto">Objeto <see cref="Boleto"/> contendo os dados do boleto.</param>
        /// <returns>Dicionário de parâmetros para envio à API BoletoCloud.</returns>
        public static Dictionary<string, string> MontarParametrosBoleto(Boleto boleto)
        {
            return new Dictionary<string, string>
            {
                ["boleto.titulo"] = boleto.Titulo,
                ["boleto.documento"] = boleto.Documento,
                ["boleto.numero"] = boleto.Numero,
                //["boleto.sequencial"] = boleto.Sequencial.ToString(),
                ["boleto.emissao"] = boleto.Emissao.ToString("yyyy-MM-dd"),
                ["boleto.vencimento"] = boleto.Vencimento.ToString("yyyy-MM-dd"),
                ["boleto.valor"] = boleto.Valor.ToString("F2", System.Globalization.CultureInfo.InvariantCulture),

                ["boleto.beneficiario.nome"] = boleto.Beneficiario.Nome,
                ["boleto.beneficiario.cprf"] = MascaraCpf(boleto.Beneficiario.Cprf),
                ["boleto.beneficiario.endereco.cep"] = MascaraCep(boleto.Beneficiario.Cep),
                ["boleto.beneficiario.endereco.uf"] = boleto.Beneficiario.Uf,
                ["boleto.beneficiario.endereco.localidade"] = boleto.Beneficiario.Localidade,
                ["boleto.beneficiario.endereco.bairro"] = boleto.Beneficiario.Bairro,
                ["boleto.beneficiario.endereco.logradouro"] = boleto.Beneficiario.Logradouro,
                ["boleto.beneficiario.endereco.numero"] = boleto.Beneficiario.Numero,
                ["boleto.conta.banco"] = boleto.Conta.Banco,
                ["boleto.conta.agencia"] = boleto.Conta.Agencia,
                ["boleto.conta.numero"] = boleto.Conta.Numero,
                ["boleto.conta.carteira"] = boleto.Conta.Carteira,
                ["boleto.pagador.nome"] = boleto.Pagador.Nome,
                ["boleto.pagador.cprf"] = MascaraCpf(boleto.Pagador.Cprf),
                ["boleto.pagador.endereco.cep"] = MascaraCep(boleto.Pagador.Cep),
                ["boleto.pagador.endereco.uf"] = boleto.Pagador.Uf,
                ["boleto.pagador.endereco.localidade"] = boleto.Pagador.Localidade,
                ["boleto.pagador.endereco.bairro"] = boleto.Pagador.Bairro,
                ["boleto.pagador.endereco.logradouro"] = boleto.Pagador.Logradouro,
                ["boleto.pagador.endereco.numero"] = boleto.Pagador.Numero
            };
        }

        /// <summary>
        /// Aplica máscara ao CPF informado.
        /// </summary>
        /// <param name="cpf">CPF sem formatação.</param>
        /// <returns>CPF formatado (000.000.000-00) ou valor original se inválido.</returns>
        private static string MascaraCpf(string cpf)
        {
            var numeros = new string(cpf.Where(char.IsDigit).ToArray());

            if (numeros.Length == 11)
                return Convert.ToUInt64(numeros).ToString(@"000\.000\.000\-00");

            return cpf;
        }

        /// <summary>
        /// Aplica máscara ao CNPJ informado.
        /// </summary>
        /// <param name="cnpj">CNPJ sem formatação.</param>
        /// <returns>CNPJ formatado (00.000.000/0000-00) ou valor original se inválido.</returns>
        private static string MascaraCnpj(string cnpj)
        {
            var numeros = new string(cnpj.Where(char.IsDigit).ToArray());
            if (numeros.Length == 14)
                return Convert.ToUInt64(numeros).ToString(@"00\.000\.000\/0000\-00");

            return cnpj;
        }

        /// <summary>
        /// Aplica máscara ao CEP informado.
        /// </summary>
        /// <param name="cep">CEP sem formatação.</param>
        /// <returns>CEP formatado (00000-000) ou valor original se inválido.</returns>
        private static string MascaraCep(string cep)
        {
            var numeros = new string(cep.Where(char.IsDigit).ToArray());
            if (numeros.Length == 8)
                return Convert.ToUInt64(numeros).ToString(@"00000\-000");

            return cep;
        }
    }
}
