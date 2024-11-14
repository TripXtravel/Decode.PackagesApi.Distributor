﻿
namespace Decode.PackagesApi.Distributor.Common.Models
{
    public class AccomodationRequest
    {
        public string Currency { get; set; }
        public string Language { get; set; }
        public string SearchId { get; set; }
        public IEnumerable<Traveller> Traveller { get; set; }
        public int Rooms { get; set; }
    }
}