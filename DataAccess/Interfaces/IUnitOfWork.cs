using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IAdministrativeRepository Administrative { get; }

        ICustomerRepository Customer { get; }

        IRoomRepository Room { get; }

        IReservationRepository Reservation { get; }

        Context DbContext { get; }

        int SaveChanges();
    }
}
