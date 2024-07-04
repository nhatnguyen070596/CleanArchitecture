using System;
using Member.Application_.Services.Interface;
using Member.Domain.DTOs;
using Member.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Member.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices productService;
        public ProductsController(IProductServices productService)
		{
            this.productService = productService;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<List<ProductResponse>> GetProducts()
        {
            return Ok(this.productService.GetProducts());
        }

        [HttpGet("{id}")]
        public ActionResult GetProductById(int id)
        {
            try
            {
                var product = this.productService.GetProductById(id);
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Create(CreateProductRequest request)
        {
            var product = this.productService.CreateProduct(request);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, UpdateProductRequest request)
        {
            try
            {
                var product = this.productService.UpdateProduct(id, request);
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                this.productService.DeleteProductById(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}

