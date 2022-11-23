using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/HotelManagement/Customers")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly CustomerOperations customerOperation = new CustomerOperations();

        /// <summary>
        /// Get
        /// </summary>
        /// <returns>List of objects</returns>
        [HttpGet]
        [Route(nameof(GetCustomers))]
        public IEnumerable<Customer> GetCustomers()
        {
            return customerOperation.GetCustomers().ToList();
        }


        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Added Succesfully</returns>
        [HttpPost]
        [Route(nameof(Insert))]
        public string Insert(Customer customer)
        {
            return customerOperation.InsertCustomer(customer);
        }

        /// <summary>
        /// Modify
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Modified Succesfully</returns>
        [HttpPost]
        [Route(nameof(Modify))]
        public string Modify(Customer customer)
        {
            return customerOperation.ModifyCustomer(customer);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deleted Succesfully</returns>
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return customerOperation.DeleteCustomer(id);
        }

    }
}
