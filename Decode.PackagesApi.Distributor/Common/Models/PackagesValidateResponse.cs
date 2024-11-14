using System.Text.Json.Serialization;

namespace Decode.PackagesApi.Distributor.Common.Models
{
    public class PackagesValidateResponse
    {
        public string ValidationId { get; set; }
        public string Message { get; set; }
    }
}
