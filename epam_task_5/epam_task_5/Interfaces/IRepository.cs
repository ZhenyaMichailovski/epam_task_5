using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_5.DataAccess.Interfaces
{
    public interface IRepository<T>
           where T : class
    {
        int Create(T item);

        T GetById(int id);

        IQueryable<T> GetAll();

        void Update(T item);

        void Delete(int id);
    }
}
