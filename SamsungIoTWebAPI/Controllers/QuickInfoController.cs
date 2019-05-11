using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SamsungIoTWebAPI.Services;
using Shared.Models;
using Shared.Utilities;

namespace SamsungIoTWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuickInfoController : ControllerBase
    {
        private readonly IBoilerStatusStorage _boilerStatusStorage;

        public QuickInfoController(IBoilerStatusStorage boilerStatusStorage)
        {
            _boilerStatusStorage = boilerStatusStorage;
        }
        // GET: api/QuickInfo
        [HttpGet]
        public async Task<ActionResult<QuickInfo>> GetAsync()
        {
            var result = await _boilerStatusStorage.GetQuickInfo(Constants.defaultUserName);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

    }
}
