using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iia.contracts.interfaces;
using iia.contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iia_host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseAPIController
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _productService.GetProductsAsync();
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Products request)
        {
            var result = await _productService.AddProduct(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProducts([FromBody] Products request)
        {
            var result = await _productService.UpdateProduct(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            await _productService.DeleteProduct(Id);
            return Ok(string.Empty);
        }
    }
}