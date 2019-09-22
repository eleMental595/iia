using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iia.contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iia_host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseAPIController : ControllerBase
    {
        public IActionResult Ok<T>(T response)
        {
            var result = new ApiSuccessResponse<T>(response);
            return base.Ok(result);
        }
    }
}