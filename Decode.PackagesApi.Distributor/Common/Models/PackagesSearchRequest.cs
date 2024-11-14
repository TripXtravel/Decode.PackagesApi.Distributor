namespace Decode.PackagesApi.Distributor.Common.Models
{
    public class PackagesSearchRequest
    {
        public SearchParameters SearchParameters { get; set; }
        public IEnumerable<AccomodationRequest> Accomodation { get; set; } = new List<AccomodationRequest>();
        public IEnumerable<TransportSearchRequest> Transport { get; set; } = new List<TransportSearchRequest>();

    }
}
