namespace BoletoCloudApi.Api.ViewModels
{
    /// <summary>
    /// ViewModel para representar um arquivo personalizado que pode ser retornado pela API.
    /// </summary>
    public class CustomFileResult
    {
        /// <summary>
        /// Bytes do arquivo.
        /// </summary>
        public byte[] FileBytes { get; set; }

        /// <summary>
        /// Content type do arquivo, como "application/pdf" ou "image/png".
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        ///  Filename do arquivo, como "boleto.pdf" ou "imagem.png".
        /// </summary>
        public string FileName { get; set; }
    }
}
