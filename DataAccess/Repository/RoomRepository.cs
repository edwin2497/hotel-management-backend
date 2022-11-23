using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(Context context) : base(context)
        {
        }

        public List<Room> GetAvailableRooms()
        {
            List<Room> availableRooms = new List<Room>();
            availableRooms =  _context.Room.Where(x => x.Status == "Available").ToList();
            return availableRooms;
        }

        public void ChangeRoomToOccupied(int roomId)
        {
            Room room = _context.Room.Where(x => x.Id == roomId).SingleOrDefault();
            if (room.Status == "Available")
            {
                room.Status = "Occupied";
            }
            _context.SaveChanges();
        }


    }
}
