using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public  interface IRepository<T> where T : class
    {
        T GetId(int id);
        
        string Insert(T entity);
        
        string Modify(T entity);
        
        string Delete(T entity);

        List<T> GetAll();

    }
}
