using Decode.PackagesApi.Distributor.Common.ExternalModels;
using Decode.PackagesApi.Distributor.Common.Models;
using Decode.PackagesApi.Distributor.Common.Options;
using Decode.PackagesApi.Distributor.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Decode.PackagesApi.Distributor.Services
{
    public class CombinatorService : ICombinatorService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly CombinatorOptions combinatorOptions;

        public CombinatorService(IHttpClientFactory httpClientFactory, IOptions<CombinatorOptions> combinatorOptions)
        {
            _httpClientFactory = httpClientFactory;
            this.combinatorOptions = combinatorOptions.Value;
        }

        public Task<PackagesBookResponse> BookAsync(PackagesBookRequest request)
        {
            return Task.FromResult(new PackagesBookResponse()
            {
                NFTImage = "https://camino-json.s3.eu-west-1.amazonaws.com/images/NFTtravel.png",
                NFTJson = "https://camino-json.s3.eu-west-1.amazonaws.com/contracts/Package.json"
            });
        }

        public async Task<PackagesSearchResponse> SearchAsync(PackagesSearchRequest request)
        {
            var response = new PackagesSearchResponse();

            var httpClient = _httpClientFactory.CreateClient();
            // Create the HttpRequestMessage
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"{combinatorOptions.URL}/packages/search")
            {
                Content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json")
            };
            // Send the request
            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var contentStream =
                    await httpResponseMessage.Content.ReadAsStringAsync();

                var combinatorResponse = JsonConvert.DeserializeObject
                    <PackagesSearchResponseExternal>(contentStream);

                response.Hotels = combinatorResponse.Hotels.Select(x => new Hotel()
                {
                    Id = x.ResultId.ToString(),
                    Rooms = x.Units.Select(u => new Room
                    {
                        Adults = 2,
                        TravellerIds = u.TravellerIds.ToList(),
                        Type = u.Type.ToString(),

                    }).ToList(),
                    Remarks = x.Remarks,
                    Bookability = x.Bookability.ToString(),
                    CheckIn = request.SearchParameters.DepartureDate,
                    CheckOut = request.SearchParameters.ReturnDate,
                    Images = ImageURL,
                    Name = $"Hotel name {new[] { "A", "B", "C", "D", "E" }[x.ResultId % 5]}"
                }).ToList();

                response.Flights = combinatorResponse.Flights.Select(x => new Flight()
                {
                    Id = x.ResultId.ToString(),
                    Bookability = x.Bookability.ToString(),
                    Legs = x.TravellingTrips.SelectMany(t => t.Segments.Select(s => new Leg
                    {
                        DepartureAirport = s.Departure.LocationCode.Code,
                        DestinationAirport = s.Arrival.LocationCode.Code,
                        DepartureTime = request.SearchParameters.DepartureDate.AddHours(12),
                        ArrivalTime = request.SearchParameters.ReturnDate.AddHours(18)
                    })).ToList()
                }).ToList();

                response.Packages = combinatorResponse.Packages.Select(x => new Common.Models.Packages()
                {
                    Id = x.Id,
                    Hotelid = x.Hotelid,
                    FlightId = x.FlightId,
                    Price = new Price()
                    {
                        Currency = "CAM",
                        Total = (new Random()).Next(3, 10)
                    }
                }).ToList();
            }

            return response;
        }

        private static readonly List<string> ImageURL = new()
        {
            "https://camino-json.s3.eu-west-1.amazonaws.com/images/hotel/1.jpg",
            "https://camino-json.s3.eu-west-1.amazonaws.com/images/hotel/2.jpg",
            "https://camino-json.s3.eu-west-1.amazonaws.com/images/hotel/3.jpg",
            "https://camino-json.s3.eu-west-1.amazonaws.com/images/hotel/4.jpg",
            "https://camino-json.s3.eu-west-1.amazonaws.com/images/hotel/5.jpg"
        };

        public Task<PackagesValidateResponse> ValidateAsync(PackagesValidateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
