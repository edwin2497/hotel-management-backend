using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _db;

        private IAdministrativeRepository _Administrative;
        private ICustomerRepository _Customer;
        private IRoomRepository _Room;
        private IReservationRepository _Reservation;


        public Context DbContext
        {
            get { return _db; }
        }

        public IAdministrativeRepository Administrative
        {
            get
            {
                if (this._Administrative == null)
                {
                    this._Administrative = new AdministrativeRepository(_db);
                }
                return this._Administrative;
            }
        }

        public ICustomerRepository Customer
        {
            get
            {
                if (this._Customer == null)
                {
                    this._Customer = new CustomerRepository(_db);
                }
                return this._Customer;
            }
        }

        public IRoomRepository Room
        {
            get
            {
                if (this._Room == null)
                {
                    this._Room = new RoomRepository(_db);
                }
                return this._Room;
            }
        }

        public IReservationRepository Reservation
        {
            get
            {
                if (this._Reservation == null)
                {
                    this._Reservation = new ReservationRepository(_db);
                }
                return this._Reservation;
            }
        }

        public UnitOfWork()
        {
            _db = new Context();

        }
        public void Dispose()
        {

        }

        public int SaveChanges()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            return 1;
        }

    }
}
