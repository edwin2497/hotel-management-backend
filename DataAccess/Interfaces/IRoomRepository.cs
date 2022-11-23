using Entities;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IRoomRepository : IRepository<Room>
    {
        List<Room> GetAvailableRooms();

        void ChangeRoomToOccupied(int roomId)
        {

        }
    }
}
