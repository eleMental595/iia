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
    public class PurchaseController : BaseAPIController
    {
        private IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPurchases()
        {
            var result = await _purchaseService.GetPurchasesAsync();
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] PurchaseEntryRequest request)
        {
            var result = await _purchaseService.AddPurchaseEntryAsync(request);
            return Ok(result);
        }
    }
}