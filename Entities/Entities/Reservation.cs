using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Reservation
    {
        #region Properties
        public int Id { get; set; }

        [ForeignKey("Customer")]
        [Required]
        public int IdCustomer { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Room")]
        [Required]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        [Required]
        public DateTime CheckIn { get; set; }


        [Required]
        public DateTime CheckOut { get; set; }

        #endregion

        #region Constructors

        public Reservation(int id, int idCustomer, Customer customer, int roomId, Room room, DateTime checkIn, DateTime checkOut)
        {
            Id=id;
            IdCustomer=idCustomer;
            Customer=customer;
            RoomId=roomId;
            Room=room;
            CheckIn=checkIn;
            CheckOut=checkOut;
        }

        public Reservation()
        {
            
        }


        #endregion
    }

}
