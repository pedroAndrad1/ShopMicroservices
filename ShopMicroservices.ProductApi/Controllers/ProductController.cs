﻿using Asp.Versioning;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMicroservices.MassTransitContracts.Contracts;
using ShopMicroservices.ProductApi.Application.Models;
using ShopMicroservices.ProductApi.Domain.Repositories;
using ShopMicroservices.ProductApi.Domain.Services;

namespace ShopMicroservices.ProductApi.Controllers;

[ApiVersion("1.0")]
[Route("api/[controller]")]
[ApiConventionType(typeof(DefaultApiConventions))]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;
    private readonly IBusService _busService;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IProductRepository repository, IBusService busService, ILogger<ProductController> logger)
    {
        _repository = repository;
        _busService = busService;
        _logger = logger;
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

        CreateDiscountToNewProduct message = new CreateDiscountToNewProduct()
        {
            Name = product.Name,
            Description = product.Description
        };
        await _busService.Send("ShopMicroservices.MassTransitContracts.Contracts:CreateDiscountToNewProduct", message);

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

    [HttpGet("health")]
    public ActionResult HealthCheck()
    {
        _logger.LogInformation("Fazendo HealthCheck com o Consul");
        return Ok();
    }
}
