namespace BoletoCloudApi.Business.Models
{
    public class BoletoPdfResult
    {
        public byte[] PdfBytes { get; set; }
        public string? Token { get; set; }
    }
}
