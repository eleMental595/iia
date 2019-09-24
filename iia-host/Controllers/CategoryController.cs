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
    public class CategoryController : BaseAPIController
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _categoryService.GetCategoriesAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategories([FromBody] CategoryRequest request)
        {
            var result = await _categoryService.AddCategory(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategories([FromBody] CategoryRequest request)
        {
            var result = await _categoryService.UpdateCategory(request);
            return Ok(result);
        }
    }
}