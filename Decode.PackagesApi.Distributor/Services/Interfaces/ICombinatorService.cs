using Decode.PackagesApi.Distributor.Common.Models;

namespace Decode.PackagesApi.Distributor.Services.Interfaces
{
    public interface ICombinatorService
    {
        public Task<PackagesSearchResponse> SearchAsync(PackagesSearchRequest request);
        public Task<PackagesValidateResponse> ValidateAsync(PackagesValidateRequest request);
        public Task<PackagesBookResponse> BookAsync(PackagesBookRequest request);
    }
}
