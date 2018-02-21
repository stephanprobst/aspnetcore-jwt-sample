using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TokenService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet, Authorize]
        public IEnumerable<string> Get()
        {
            // Only with authorize
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            // Check specific claims
            if (HttpContext.User.HasClaim(claim => claim.Type == ClaimTypes.Email))
            {
                return HttpContext.User.FindFirst(claim => claim.Type == ClaimTypes.Email)
                                       .Value;
            }

            return "value";
        }
    }
}
