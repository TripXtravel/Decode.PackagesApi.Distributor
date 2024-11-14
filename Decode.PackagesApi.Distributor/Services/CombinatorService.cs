using Decode.PackagesApi.Distributor.Common.ExternalModels;
using Decode.PackagesApi.Distributor.Common.Models;
using Decode.PackagesApi.Distributor.Common.Options;
using Decode.PackagesApi.Distributor.Services.Interfaces;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text.Json;

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
            throw new NotImplementedException();
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
                        Type = u.Type.ToString()
                    }).ToList(),
                    Remarks = x.Remarks,
                    Bookability = x.Bookability.ToString(),
                    CheckIn = DateTime.Now.AddDays(20),
                    CheckOut = DateTime.Now.AddDays(27)
                }).ToList();

                response.Flights = combinatorResponse.Flights.Select(x => new Flight()
                {
                    Id = x.ResultId.ToString(),
                    Bookability = x.Bookability.ToString(),
                    Legs = x.TravellingTrips.SelectMany(t => t.Segments.Select(s => new Leg
                    {
                        DepartureAirport = s.Departure.LocationCode.Code,
                        DestinationAirport = s.Arrival.LocationCode.Code,
                        DepartureTime = DateTime.Now.AddDays(20),
                        ArrivalTime = DateTime.Now.AddDays(27)
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

        public Task<PackagesValidateResponse> ValidateAsync(PackagesValidateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
