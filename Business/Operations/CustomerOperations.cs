using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class CustomerOperations
    {

        IUnitOfWork uow = new UnitOfWork(); //Create instance towards data access for SQL



        /// <summary> Method to list the items entered in the database</summary>
        ///<returns> List of objects </returns>

        public List<Customer> GetCustomers()
        {
            MongoDBAccess mongoDB = new MongoDBAccess(); ///Create instace towards data access for Mongo

            Audit audit = new Audit("Customers query made", DateTime.Now); ///Create audit type object to be added to mongo

            mongoDB.Add(audit); ///Add the previously created object

            return uow.Customer.GetAll(); ///Return list of rooms
        }


        ///<summary> Method to add new  object </summary>
        /// <param name="customer"></param>
        ///<returns>Added successfully</returns>
        public string InsertCustomer(Customer customer)
        {
            try
            {
                MongoDBAccess mongoDB = new MongoDBAccess(); ///Create instace towards data access for Mongo

                Audit audit = new Audit("New customer added", DateTime.Now); ///Create audit type object to be added to mongo

                mongoDB.Add(audit); ///Add the previously created object

                return uow.Customer.Insert(customer); ///Add the object to the database
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error CustomerOperations.Insert: {ex.Message}"); ///Print error message
                throw ex;
            }

        }



        ///<summary>Method to modify customer object</summary>
        /// <param name="customer"></param>
        ///<returns> Modified successfully</returns>
        public string ModifyCustomer(Customer customer)
        {
            try
            {
                MongoDBAccess mongoDB = new MongoDBAccess(); ///Create instace towards data access for Mongo

                Audit audit = new Audit("Customer modified", DateTime.Now); ///Create audit type object to be added to mongo

                mongoDB.Add(audit); ///Add the previously created object

                Customer uowCustomer = uow.Customer.GetId(customer.Id); ///Search for object in database

                if (uowCustomer != null)  ///Validates if the object exist
                {
                    uow.DbContext.Entry(uowCustomer).CurrentValues.SetValues(customer);

                    return uow.Customer.Modify(uowCustomer);///Update the object on the database
                }
                return "Customer not found";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error CustomerOperations.Modify: {ex.Message}"); ///Print error message
                throw ex;
            }

        }



        ///<summary>Method to deletes object</summary>
        /// <param name="id"></param>
        ///<returns> Deleted successfully</returns>
        public string DeleteCustomer(int id)
        {
            try
            {
                MongoDBAccess mongoDB = new MongoDBAccess(); ///Create instace towards data access for Mongo

                Audit audit = new Audit("Customer deleted", DateTime.Now); ///Create audit type object to be added to mongo
                
                mongoDB.Add(audit); ///Add the previously created object

                Customer uowCustomer = uow.Customer.GetId(id); ///Search for object in databases

                if (uowCustomer != null) ///Validates if the object exist
                {
                    return uow.Customer.Delete(uowCustomer);
                }
                return "Customer not found";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error CustomerOperations.Delete: {ex.Message}"); ///Print error message
                throw ex;
            }
        }
    }
}
