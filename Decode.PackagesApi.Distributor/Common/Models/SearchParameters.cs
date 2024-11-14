
namespace Decode.PackagesApi.Distributor.Common.Models
{
    public class SearchParameters
    {
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
    }
}