using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class RoomOperations
    {
        IUnitOfWork uow = new UnitOfWork(); ///Create instance towards data access



        /// <summary> Method to list the items entered in the database</summary>
        ///<returns> List of type Room </returns>

        public List<Room> GetRooms()
        {
            MongoDBAccess mongoDB = new MongoDBAccess(); ///Create instace towards data access for Mongo

            Audit audit = new Audit("Rooms query made", DateTime.Now); ///Create audit type object to be added to mongo

            mongoDB.Add(audit); ///Add the previously created object

            return uow.Room.GetAll(); ///Return list of rooms
        }

        public List<Room> GetAvailableRooms()
        {
            MongoDBAccess mongoDB = new MongoDBAccess(); ///Create instace towards data access for Mongo

            Audit audit = new Audit("Rooms query made", DateTime.Now); ///Create audit type object to be added to mongo

            mongoDB.Add(audit); ///Add the previously created object

            return uow.Room.GetAvailableRooms(); ///Return list available of rooms
        }



        ///<summary> Method to add new room object </summary>
        /// <param name="room"></param>
        ///<returns>Added successfully</returns>
        public string InsertRoom(Room room)
        {
            try
            {
                MongoDBAccess mongoDB = new MongoDBAccess(); ///Create instace towards data access for Mongo

                Audit audit = new Audit("New room added", DateTime.Now); ///Create audit type object to be added to mongo

                mongoDB.Add(audit); ///Add the previously created object

                return uow.Room.Insert(room); ///Add the room object to the database
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error RoomOperations.Insert: {ex.Message}"); ///Print error message
                throw ex;
            }

        }



        ///<summary>Method to modify room object</summary>
        /// <param name="room"></param>
        ///<returns> Modified successfully</returns>
        public string ModifyRoom(Room room)
        {
            try
            {
                MongoDBAccess mongoDB = new MongoDBAccess(); ///Create instace towards data access for Mongo

                Audit audit = new Audit("Room modified", DateTime.Now); ///Create audit type object to be added to mongo

                mongoDB.Add(audit); ///Add the previously created object

                Room uowRoom = uow.Room.GetId(room.Id); ///Search for object in database

                if (uowRoom != null)  ///Validates if the room exist
                {
                    uow.DbContext.Entry(uowRoom).CurrentValues.SetValues(room);

                    return uow.Room.Modify(uowRoom);///Update the room object on the database
                }
                return "Room not found";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error RoomOperations.Modify: {ex.Message}"); ///Print error message
                throw ex;
            }

        }



        ///<summary>Method to delete room object</summary>
        /// <param name="id"></param>
        ///<returns> Deleted successfully</returns>
        public string DeleteRoom(int id)
        {
            try
            {
                MongoDBAccess mongoDB = new MongoDBAccess(); ///Create instace towards data access for Mongo

                Audit audit = new Audit("Room deleted", DateTime.Now); ///Create audit type object to be added to mongo

                mongoDB.Add(audit); ///Add the previously created object

                Room uowRoom = uow.Room.GetId(id); ///Search for object in database

                if (uowRoom != null) ///Validates if the room exist
                {
                    return uow.Room.Delete(uowRoom);
                }
                return "Room not found";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error RoomOperations.Delete: {ex.Message}"); ///Print error message
                throw ex;
            }
        }


        ///<summary>Method to change room status</summary>
        /// <param name="roomId"></param>
        ///<returns></returns>
        public void ChangeRoomStatus(int roomId)
        {
            try
            {
                Room uowRoom = uow.Room.GetId(roomId); ///Search for object in database

                uowRoom.Status = "Occupied"; ///Change the status of the room
                
                ModifyRoom(uowRoom); /// Update the searched room
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error RoomOperations.ChangeStatus: {ex.Message}"); ///Print error message
                throw ex;
            }

        }
    }
}
