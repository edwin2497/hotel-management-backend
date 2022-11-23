using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(Context context) : base(context)
        {
        }
    }
}
