﻿using API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("Error/(code)")]
    [ApiController]
    public class ErrorController : BaseApiController
    {
        public IActionResult Error (int Code)
        {
            return new ObjectResult(new ApiResponse(Code));
        }
    }
}