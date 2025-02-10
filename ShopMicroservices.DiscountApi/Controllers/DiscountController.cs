using Microsoft.AspNetCore.Mvc;
using ShopMicroservices.DiscountApi.Application.Models;
using ShopMicroservices.DiscountApi.Domain.Repositories;

namespace ShopMicroservices.DiscountApi.Controllers
{
    [Route("api/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _repository;
        private readonly ILogger<DiscountController> _logger;

        public DiscountController(IDiscountRepository repository, ILogger<DiscountController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("{productName}", Name = "GetDiscount")]
        public async Task<IActionResult> GetDiscount(string productName)
        {
            var result = await _repository.GetDiscount(productName);

            if(result is null)
            {
                return NotFound("Discount not found");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(Coupon coupon)
        {
            await _repository.CreateDiscount(coupon);

            return CreatedAtRoute("GetDiscount", routeValues: new { coupon.ProductName }, value: coupon);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscount(Coupon coupon)
        {
            await _repository.UpdateDiscount(coupon);
            return Ok(coupon);
        }

        [HttpDelete("{productName}")]
        public async Task<IActionResult> DeleteDiscount(string productName)
        {
            var success = await _repository.DeleteDiscount(productName);
            if (!success)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet("/init-db")]
        public async Task<IActionResult> InitDb()
        {
            await _repository.InitializeDb();
            return Ok();
        }

        [HttpGet("health")]
        public ActionResult HealthCheck()
        {
            _logger.LogInformation("Fazendo HealthCheck com o Consul");
            return Ok();
        }
    }
}
