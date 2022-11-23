using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {

        public readonly Context _context;

        private DbSet<T> _entity;

        private DbSet<T> Entities
        {
            get
            {
                if (_entity == null)
                {
                    _entity = _context.Set<T>();
                }
                return _entity;
            }
        }

        public Repository(Context context)
        {
            _context = context;
        }

        public T GetId(int id)
        {
            return this.Entities.Find(id);
        }

        public List<T> GetAll()
        {
            try
            {
                return this.Entities.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Add(entity);
                this._context.SaveChanges();
                return "Added successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Modify(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this._context.SaveChanges();
                return "Modified successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public string Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Remove(entity);
                this._context.SaveChanges();
                return "Deleted successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
