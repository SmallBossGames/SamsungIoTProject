using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SamsungIoTWebAPI.Models;
using Shared.Models;

namespace SamsungIoTWebAPI.Services
{
    public class BoilerStatusStorage : IBoilerStatusStorage
    {
        private readonly SamsungIoTWebAPIContext _context;
        public BoilerStatusStorage(SamsungIoTWebAPIContext context)
        {
            _context = context;
        }

        public async Task<QuickInfo> GetQuickInfo(string userId)
        {
            var query = from roomInfo in _context.RoomStatus
                        where roomInfo.UserId == userId
                        group roomInfo by roomInfo.RoomNumber into roomGroupInfo
                        let maxDate = roomGroupInfo.Max(x => x.UpdateTime)
                        from roomInfo in roomGroupInfo
                        where roomGroupInfo.Max(x => x.UpdateTime) == roomInfo.UpdateTime
                        select roomInfo;

            var avgHumidity = await query.AverageAsync(x => x.AirHumidity);

            var avgTemperature = await query.AverageAsync(x => x.Temperature);

            var boilerLastStatus = await
                (from boilerInfo in _context.BoilerStatus
                 where boilerInfo.UserId == userId
                 orderby boilerInfo.UpdateTime
                 select boilerInfo).LastOrDefaultAsync();

            if(boilerLastStatus == null)
            {
                return null;
            }

            return new QuickInfo
            {
                AvgHumidity = avgHumidity,
                AvgTemperature = avgTemperature,
                HeatCarrierTemperature = boilerLastStatus.HeatCarrierTemperature,
                LeakOfGasStatus = boilerLastStatus.LeakOfGasSatus
            };
        }

        public Task<BoilerStatus> GetLastBoilerStatus(string userId)
        {
            return
                (from boilerInfo in _context.BoilerStatus
                 where boilerInfo.UserId == userId
                 orderby boilerInfo.UpdateTime
                 select boilerInfo).LastOrDefaultAsync();
        }

        public Task<List<RoomStatus>> GetLastRoomStatus(string userId)
        {
            return
                GetRoomLastStatusQuery(userId)
                .Select(x => x).ToListAsync();
        }

        public Task<RoomStatus> GetLastRoomStatus(string userId, int roomNumber)
        {
            return
                GetRoomLastStatusQuery(userId)
                .Select(x => x)
                .FirstOrDefaultAsync(x => x.RoomNumber == roomNumber);
        }

        private IQueryable<RoomStatus> GetRoomLastStatusQuery(string userId)
        {
            return from roomInfo in _context.RoomStatus
                   where roomInfo.UserId == userId
                   group roomInfo by roomInfo.RoomNumber into roomGroupInfo
                   let roomLastStatus =
                       (from roomInfo in roomGroupInfo
                        orderby roomInfo.UpdateTime
                        select roomInfo).Last()
                   select roomLastStatus;
        }
    }
}
