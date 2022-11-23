using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/HotelManagement/Rooms")]
    [ApiController]
    public class RoomsController : Controller
    {

        private readonly RoomOperations roomOperation = new RoomOperations();

        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Get
        /// </summary>
        /// <returns>List of objects</returns>
        [HttpGet]
        [Route(nameof(GetRooms))]
        public IEnumerable<Room> GetRooms()
        {
            return roomOperation.GetRooms().ToList();
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns>List of objects</returns>
        [HttpGet]
        [Route(nameof(GetAvailableRooms))]
        public IEnumerable<Room> GetAvailableRooms()
        {
            return roomOperation.GetAvailableRooms().ToList();
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="room"></param>
        /// <returns>Added Succesfully</returns>
        [HttpPost]
        [Route(nameof(Insert))]
        public string Insert(Room room)
        {
            return roomOperation.InsertRoom(room);
        }


        /// <summary>
        /// Modify
        /// </summary>
        /// <param name="room"></param>
        /// <returns>Modified Succesfully</returns>
        [HttpPost]
        [Route(nameof(Modify))]
        public string Modify(Room room)
        {
            return roomOperation.ModifyRoom(room);
        }


        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deleted Succesfully</returns>
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return roomOperation.DeleteRoom(id);
        }
    }
}