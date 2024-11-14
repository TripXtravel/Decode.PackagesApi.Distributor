namespace Decode.PackagesApi.Distributor.Common.Models
{
    public class PackagesSearchResponse
    {
        public string SearchToken { get; set; }
        public string LanguageCode { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<Flight> Flights { get; set; }
        public List<Packages> Packages { get; set; }
    }

    public class Hotel
    {
        public string Id { get; set; }
        public string ReferenceToken { get; set; }
        public string Name { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Remarks { get; set; }
        public string Bookability { get; set; }
        public List<string> Images { get; set; }
    }

    public class Flight
    {
        public string Id { get; set; }
        public string ProductToken { get; set; }
        public List<Leg> Legs { get; set; }
        public Price Prices { get; set; }
        public string Bookability { get; set; }
    }

    public class Leg
    {
        public string DepartureAirport { get; set; }
        public string DestinationAirport { get; set; }
        public int TravelTime { get; set; }
        public bool IsOvernight { get; set; }
        public bool Nonstop { get; set; }
        public string FareClass { get; set; }
        //public List<Segment> Segments { get; set; }
        //public List<Upgrade> MinimumServices { get; set; }
        public string Carrier { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int FlightTime { get; set; }
        public string AircraftIataCode { get; set; }
        public List<Upgrade> IncludedServices { get; set; }

    }

    public class Segment
    {
        public string Carrier { get; set; }
        public string DepartureAirport { get; set; }
        public string DestinationAirport { get; set; }
        public string FlightNumber { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public int FlightTime { get; set; }
        public string AircraftIataCode { get; set; }
        public List<Upgrade> IncludedServices { get; set; }
    }

    public class Upgrade
    {
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public bool PerPassenger { get; set; }
        public Weight MaxWeight { get; set; }
        public List<string> AllowedPaxTypes { get; set; }
        public List<int> AllowedPaxAges { get; set; }
    }
    public class Packages
    {
        public Guid Id { get; set; }
        public int Hotelid { get; set; }
        public int FlightId { get; set; }
        public Price Price { get; set; }
    }
}
