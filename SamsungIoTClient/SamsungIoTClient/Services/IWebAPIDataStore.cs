using System.Threading.Tasks;
using Shared.Models;

namespace SamsungIoTClient.Services
{
    public interface IWebAPIDataStore
    {
        Task<BoilerStatus> GetBoilerCurrentStatusAsync();
        Task<RoomStatus[]> GetRoomStatus();
        Task<RoomStatus> GetRoomStatus(int number);
    }
}