using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class AdministrativeRepository : Repository<Administrative>, IAdministrativeRepository
    {
        public AdministrativeRepository(Context context) : base(context)
        {
        }
    }
}
