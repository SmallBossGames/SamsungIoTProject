using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using SamsungIoTWebAPI.Services;
using Shared.Utilities;

namespace SamsungIoTWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoilerLastInfoController : ControllerBase
    {
        private readonly IBoilerStatusStorage _boilerStatusStorage;

        public BoilerLastInfoController(IBoilerStatusStorage boilerStatusStorage)
        {
            _boilerStatusStorage = boilerStatusStorage;
        }

        // GET: api/BoilerLastInfo
        [HttpGet]
        public async Task<ActionResult<BoilerStatus>> GetAsync()
        {
            var result = await _boilerStatusStorage.GetLastBoilerStatus(Constants.defaultUserName);

            if(result == null)
            {
                return NotFound();
            }

            return result;
        }
    }
}
