using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Customer
    {
        #region Properties

        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(50)]
        [Required]
        public string Phone { get; set; }

        [MaxLength(50)]
        [Required]
        public string Email { get; set; }



        #endregion


        #region Constructors

        public Customer(int id, string name, string lastName, string phone, string email)
        {
            Id=id;
            Name=name;
            LastName=lastName;
            Phone=phone;
            Email=email;
        }

        public Customer()
        {
        }


        #endregion

    }
}
