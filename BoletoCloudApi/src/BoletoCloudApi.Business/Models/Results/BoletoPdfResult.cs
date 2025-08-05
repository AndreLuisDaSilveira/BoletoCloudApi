namespace BoletoCloudApi.Business.Models.Results
{
    /// <summary>
    /// Representa o resultado da geração do PDF de um boleto, contendo os bytes do arquivo e um token de identificação.
    /// </summary>
    public class BoletoPdfResult
    {
        /// <summary>
        /// Bytes do arquivo PDF gerado do boleto.
        /// </summary>
        public byte[] PdfBytes { get; set; }

        /// <summary>
        /// Token de identificação ou autenticação relacionado ao PDF do boleto.
        /// </summary>
        public string? Token { get; set; }
    }
}
