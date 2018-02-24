using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecuredWebApi.Controllers
{
    [Route("api/[controller]"), Authorize]
    public class CarsController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Ferrari", "Porsche" };
        }
    }
}
