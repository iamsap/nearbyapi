using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nearby.Api.Data;
using Nearby.Api.Dtos;
using Nearby.Api.Repositories;

namespace Nearby.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class SubscriberController : Controller
    {
        private IRepository _repo;

        public SubscriberController(IRepository repo = null) {
            _repo = repo;
        }

        [HttpPost, MapToApiVersion("1.0"),Route("")]
        public async Task<IActionResult> Subscribe([FromBody]SubscribeRequestDto req)
        {
            if(string.IsNullOrEmpty(req.Email)) {
                return BadRequest();
            }

            var sub = Mapper.Map<Subscription>(req);

            await _repo.Save(sub);
            return Ok();
        }

        [HttpGet, MapToApiVersion("1.0"), Route("ping")]
        public string Ping()
        {
            return "pong";
        }
    }

}
