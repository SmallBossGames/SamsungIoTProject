using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace SamsungIoTWebAPI.Services
{
    public interface IBoilerStatusStorage
    {
        Task<BoilerStatus> GetLastBoilerStatus(string userId);
        Task<List<RoomStatus>> GetLastRoomStatus(string userId);
        Task<RoomStatus> GetLastRoomStatus(string userId, int roomNumber);
    }
}