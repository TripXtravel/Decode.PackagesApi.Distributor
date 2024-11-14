namespace Decode.PackagesApi.Distributor.Common.Models
{
    public class PackagesValidateRequest
    {
        public Products Products { get; set; }
        public double ClientTotalPrice { get; set; }
        public int? TransactionId { get; set; }
        public string ExternalReferenceId { get; set; }
    }

    public class Products
    {
        public Hotel[] Hotels { get; set; }
        public Flight[] Flights { get; set; }
    }
}
