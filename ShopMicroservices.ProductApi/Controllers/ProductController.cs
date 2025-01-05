using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMicroservices.ProductApi.Application.Models;
using ShopMicroservices.ProductApi.Domain.Repositories;

namespace ShopMicroservices.ProductApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiConventionType(typeof(DefaultApiConventions))]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _repository.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id}", Name = "GetProducById")]
    public async Task<ActionResult<Product>> GetProductById(string id)
    {
        var product = await _repository.GetProduct(id);
        if(product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpGet("category/{category}")]
    public async Task<ActionResult<Product>> GetProductByCategory(string category)
    {
        if(category is null)
        {
            return BadRequest();
        }

        var products = await _repository.GetProductByCategory(category);

        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        if(product is null)
        {
            return BadRequest();
        }

        await _repository.CreateProduct(product);

        return CreatedAtRoute("GetProducById", new { id = product.Id }, product);
    }

    [HttpPut]
    public async Task<ActionResult<Product>> UpdateProduct(Product product)
    {
        if (product is null)
        {
            return BadRequest();
        }

        var success = await _repository.UpdateProduct(product);

        if (!success)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(string id)
    {
        var success = await _repository.DeleteProduct(id);
        
        if (!success)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return Ok();
    }
}
