using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/HotelManagement/Reservations")]
    [ApiController]
    public class ReservationController : Controller
    {
        private readonly ReservationOperations reservationOperation = new ReservationOperations();

        /// <summary>
        /// Get
        /// </summary>
        /// <returns>List of objects</returns>
        [HttpGet]
        [Route(nameof(GetReservations))]
        public IEnumerable<Reservation> GetReservations()
        {
            return reservationOperation.GetReservations().ToArray();
        }


        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns>Added Succesfully</returns>
        [HttpPost]
        [Route(nameof(Insert))]
        public string Insert(Reservation reservation)
        {
            return reservationOperation.InsertReservation(reservation);
        }

        /// <summary>
        /// Modify
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns>Modified Succesfully</returns>
        [HttpPost]
        [Route(nameof(Modify))]
        public string Modify(Reservation reservation)
        {
            return reservationOperation.ModifyReservation(reservation);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deleted Succesfully</returns>
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return reservationOperation.DeleteReservation(id);
        }
    }
}
