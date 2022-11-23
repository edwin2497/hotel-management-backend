using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Room
    {
        #region Properties

        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [MaxLength(50)]
        [Required]
        public string Status { get; set; }

        [MaxLength(50)]
        [Required]
        public string Type { get; set; }

        [Required]
        public int Price { get; set; }

        #endregion

        #region Constructors

        public Room(int id, int number, string status, string type, int price)
        {
            Id=id;
            Number=number;
            Status=status;
            Type=type;
            Price=price;
        }

        public Room()
        {
        }

        #endregion
    }

}
