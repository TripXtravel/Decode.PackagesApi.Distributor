namespace Decode.PackagesApi.Distributor.Common.Models
{
    public class TransportSearchRequest
    {
        public IEnumerable<Traveller> Travellers { get; set; }
        public SearchParameters SearchParameters { get; set; }
    }
}