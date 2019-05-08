using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace SamsungIoTWebAPI.Models
{
    public class SamsungIoTWebAPIContext : DbContext
    {
        public SamsungIoTWebAPIContext (DbContextOptions<SamsungIoTWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Shared.Models.BoilerStatus> BoilerStatus { get; set; }

        public DbSet<Shared.Models.RoomStatus> RoomStatus { get; set; }
    }
}
