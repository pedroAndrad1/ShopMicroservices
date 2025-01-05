using Microsoft.AspNetCore.Mvc;
using ShopMicroservices.DiscountApi.Application.Models;
using ShopMicroservices.DiscountApi.Domain.Repositories;

namespace ShopMicroservices.DiscountApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiController]
    public class Discount : ControllerBase
    {
        private readonly IDiscountRepository _repository;

        public Discount(IDiscountRepository repository)
        {
            _repository = repository;
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

            return CreatedAtRoute("GetDiscount", coupon);
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


    }
}
