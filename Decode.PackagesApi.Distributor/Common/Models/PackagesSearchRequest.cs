namespace Decode.PackagesApi.Distributor.Common.Models
{
    public class PackagesSearchRequest
    {
        public IEnumerable<AccomodationRequest> Accomodation { get; set; }
        public IEnumerable<TransportSearchRequest> Transport { get; set; }

    }
}
