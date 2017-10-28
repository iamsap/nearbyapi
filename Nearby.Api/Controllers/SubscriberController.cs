using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nearby.Api.Dtos;

namespace Nearby.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class SubscriberController : Controller
    {

        [HttpPost, MapToApiVersion("1.0"),Route("")]
        public void Subscribe([FromBody]SubscribeRequestDto req)
        {
        }

        [HttpGet, MapToApiVersion("1.0"), Route("ping")]
        public string Ping()
        {
            return "pong";
        }
    }

}
