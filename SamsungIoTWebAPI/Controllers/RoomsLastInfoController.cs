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
    public class RoomsLastInfoController : ControllerBase
    {
        private readonly IBoilerStatusStorage _boilerStatusStorage;

        public RoomsLastInfoController(IBoilerStatusStorage boilerStatusStorage)
        {
            _boilerStatusStorage = boilerStatusStorage;
        }

        // GET: api/RoomsLastInfo
        [HttpGet]
        public async Task<IEnumerable<RoomStatus>> Get()
            => await _boilerStatusStorage.GetLastRoomStatus(Constants.defaultUserName);

        // GET: api/RoomsLastInfo/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<RoomStatus>> Get(int number)
        {
            var result = await _boilerStatusStorage.GetLastRoomStatus(Constants.defaultUserName, number);

            if(result == null)
            {
                return NotFound();
            }

            return result;
        }
    }
}
