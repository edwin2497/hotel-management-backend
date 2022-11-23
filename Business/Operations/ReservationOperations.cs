using DataAccess;
using Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ReservationOperations
    {
        IUnitOfWork uow = new UnitOfWork(); ///Create instance towards data access



        /// <summary> Method to list the items entered in the database</summary>
        ///<returns> List of objects </returns>

        public List<Reservation> GetReservations()
        {
            MongoDBAccess mongoDB = new MongoDBAccess(); ///Create instace towards data access for Mongo

            Audit audit = new Audit("Reservations query made", DateTime.Now); ///Create audit type object to be added to mongo

            mongoDB.Add(audit); ///Add the previously created object

            return uow.Reservation.GetAll(); ///Return list of rooms
        }


        ///<summary> Method to add new  object </summary>
        /// <param name="reservation"></param>
        ///<returns>Added successfully</returns>
        public string InsertReservation(Reservation reservation)
        {
            try
            {
                MongoDBAccess mongoDB = new MongoDBAccess(); ///Create instace towards data access for Mongo

                Audit audit = new Audit("New reservation added", DateTime.Now); ///Create audit type object to be added to mongo

                mongoDB.Add(audit); ///Add the previously created object

                RoomOperations roomOperations = new RoomOperations(); ///Create instance towards room operations
                roomOperations.ChangeRoomToOccupied(reservation.RoomId); ///Change room status


                return uow.Reservation.Insert(reservation); ///Add the object to the database
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ReservationOperations.Insert: {ex.Message}"); ///Print error message
                throw ex;
            }

        }



        ///<summary>Method to modify reservation object</summary>
        /// <param name="reservation"></param>
        ///<returns> Modified successfully</returns>
        public string ModifyReservation(Reservation reservation)
        {
            try
            {
                MongoDBAccess mongoDB = new MongoDBAccess(); ///Create instace towards data access for Mongo

                Audit audit = new Audit("Reservation modified", DateTime.Now); ///Create audit type object to be added to mongo

                mongoDB.Add(audit); ///Add the previously created object

                Reservation uowReservation = uow.Reservation.GetId(reservation.Id); ///Search for object in database

                if (uowReservation != null)  ///Validates if the object exist
                {
                    RoomOperations roomOperations = new RoomOperations(); ///Create instance towards room operations
                    roomOperations.ChangeRoomToOccupied(reservation.RoomId); ///Change room status
                    
                    uow.DbContext.Entry(uowReservation).CurrentValues.SetValues(reservation);

                    return uow.Reservation.Modify(uowReservation);///Update the object on the database
                }
                return "Reservation not found";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ReservationOperations.Modify: {ex.Message}"); ///Print error message
                throw ex;
            }

        }



        ///<summary>Method to deletes object</summary>
        /// <param name="id"></param>
        ///<returns> Deleted successfully</returns>
        public string DeleteReservation(int id )
        {
            try
            {
                MongoDBAccess mongoDB = new MongoDBAccess(); ///Create instace towards data access for Mongo

                Audit audit = new Audit("Reservation deleted", DateTime.Now); ///Create audit type object to be added to mongo

                mongoDB.Add(audit); ///Add the previously created object
                
                Reservation uowReservation = uow.Reservation.GetId(id); ///Search for object in databases

                if (uowReservation != null) ///Validates if the object exist
                {
                    return uow.Reservation.Delete(uowReservation);
                }
                return "Reservation not found";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ReservationOperations.Delete: {ex.Message}"); ///Print error message
                throw ex;
            }
        }



        ///<summary>Method to modify reservation object</summary>
        /// <param name="reservation"></param>
        ///<returns> Modified successfully</returns>
        public string FinishReservation(Reservation reservation)
        {
            try
            {
                MongoDBAccess mongoDB = new MongoDBAccess(); ///Create instace towards data access for Mongo

                Audit audit = new Audit("Reservation finished", DateTime.Now); ///Create audit type object to be added to mongo

                mongoDB.Add(audit); ///Add the previously created object

                Reservation uowReservation = uow.Reservation.GetId(reservation.Id); ///Search for object in database

                if (uowReservation != null)  ///Validates if the object exist
                {
                    reservation.Status = "Finished"; ///Change status to finished
                    
                    uow.DbContext.Entry(uowReservation).CurrentValues.SetValues(reservation);

                    return uow.Reservation.Modify(uowReservation);///Update the object on the database
                }
                return "Reservation not found";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ReservationOperations.FinishReservation: {ex.Message}"); ///Print error message
                throw ex;
            }

        }






    }
}
