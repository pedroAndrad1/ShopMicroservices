using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMicroservices.BasketApi.Application.Models;
using ShopMicroservices.BasketApi.Domain.Repositories;

namespace ShopMicroservices.BasketApi.Controllers;

[Route("api/[controller]")]
[ApiConventionType(typeof(DefaultApiConventions))]
[ApiController]
public class BasketController : ControllerBase
{
    private readonly IBasketRepository _repository;
    private readonly ILogger<BasketController> _logger;

    public BasketController(IBasketRepository repository, ILogger<BasketController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> GetBasket(string username)
    {
        var basket = await _repository.GetBasket(username);

        return Ok(basket ?? new ShoppingCart(username));
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBasket(ShoppingCart cart)
    {
        var basket = await _repository.UpdateBasket(cart);

        return Ok(basket);
    }

    [HttpDelete("{username}")]
    public async Task<IActionResult> DeleteBasket(string username)
    {
        await _repository.DeleteBasket(username);
        return Ok();
    }

    [HttpGet("health")]
    public ActionResult HealthCheck()
    {
        _logger.LogInformation("Fazendo HealthCheck com o Consul");
        return Ok();
    }
}
