using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KT.Core.Mvc.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using KT.Core.Mvc.Business;

namespace KT.Core.Mvc.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IOptions<List<Tenant>> _tenants;
        private readonly ILogger<AccountController> _logger;

        public ImagesController(
    ILogger<AccountController> logger,
    IConfiguration configuration,
    IOptions<List<Tenant>> tenants) : base
        (logger, configuration, tenants)
        {
            _logger = logger;
            _configuration = configuration;
            _tenants = tenants;
        }


        // GET: api/images
        [HttpGet]
        public IActionResult Get()
        {
            //var headers = Request.Headers;
            //var authorization = headers["Authorization"];
            IEnumerable<wp_image> result = null;
            var tenant = this.GetTenant();

            if (tenant != null)
            {
                result = Images.GetAll(tenant.ConnectionString, null, null);
                if (result != null)
                {
                    return Ok(result);
                }
            }

            return BadRequest(result);
        }

        // GET: api/AccountsContoller/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AccountsContoller
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Console.WriteLine(value);
        }

        // PUT: api/AccountsContoller/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        // POST: api/imagse/getusers
        [HttpPost("getimages")]
        //[Authorize]
        public IActionResult GetUsers()
        {
            //var headers = Request.Headers;
            //var authorization = headers["Authorization"];
            IEnumerable<wp_user> result = null;
            var tenant = this.GetTenant();

            if (tenant != null)
            {
                result = Users.GetAll(tenant.ConnectionString, null, null);
                if (result != null)
                {
                    return Ok(result);
                }
            }

            return BadRequest(result);
        }

    }
}
