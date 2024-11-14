using Decode.PackagesApi.Distributor.Common.Models;
using Decode.PackagesApi.Distributor.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Decode.PackagesApi.Distributor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PackagesController : ControllerBase
    {
        private readonly ILogger<PackagesController> _logger;
        private readonly ICombinatorService combinatorService;

        public PackagesController(ILogger<PackagesController> logger, ICombinatorService combinatorService)
        {
            _logger = logger;
            this.combinatorService = combinatorService;
        }

        [HttpGet(Name = "Search")]
        public async Task<IActionResult> SearchAsync(PackagesSearchRequest request)
        {
            var response = await combinatorService.SearchAsync(request);
            return new OkObjectResult(response);
        }

        [HttpPost(Name = "Validate")]
        public async Task<IActionResult> ValidateAsync(PackagesValidateRequest request)
        {
            var response = await combinatorService.ValidateAsync(request);
            return new OkObjectResult(response);
        }

        [HttpPost(Name = "Book")]
        public IActionResult Book(PackagesBookRequest request)
        {
            var response = combinatorService.BookAsync(request);
            return new OkObjectResult(response);
        }
    }
}