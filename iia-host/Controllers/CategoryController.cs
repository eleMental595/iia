using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iia.contracts.interfaces;
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

        [HttpGet("Categories")]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _categoryService.GetCategoriesAsync();
            return Ok(result);
        }
    }
}