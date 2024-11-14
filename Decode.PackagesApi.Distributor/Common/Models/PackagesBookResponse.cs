namespace Decode.PackagesApi.Distributor.Common.Models
{
    public class PackagesBookResponse
    {
        public string BookTransactionId { get; set; }
        public string MintTransactionId { get; set; }
        public string NFTJson { get; set; }
        public string NFTImage { get; set; }
        public DateTime ExpiresAt { get; set; }

    }
}
