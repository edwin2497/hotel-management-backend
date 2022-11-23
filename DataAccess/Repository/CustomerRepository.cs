using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(Context context) : base(context)
        {
        }
    }
}
