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
    public class CustomerController : BaseAPIController
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var result = await _customerService.GetCustomersAsync();
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] Customer request)
        {
            var result = await _customerService.AddCustomer(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer request)
        {
            var result = await _customerService.UpdateCustomer(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int Id)
        {
            await _customerService.DeleteCustomer(Id);
            return Ok(string.Empty);
        }
    }
}