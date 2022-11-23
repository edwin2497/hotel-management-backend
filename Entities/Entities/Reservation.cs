using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [MaxLength(50)]
        [Required]
        public string Status { get; set; }

        #endregion

        #region Constructors

        public Reservation(int id, int idCustomer, int roomId,  DateTime checkIn, DateTime checkOut, string status)
        {
            Id=id;
            IdCustomer=idCustomer;
            RoomId=roomId;
            CheckIn=checkIn;
            CheckOut=checkOut;
            Status=status;
        }

        public Reservation()
        {
            
        }


        #endregion
    }

}
