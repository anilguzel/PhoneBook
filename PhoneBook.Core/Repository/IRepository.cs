using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Core.Entities.Abstract;

namespace PhoneBook.Core.Repository
{
    public interface IRepository<T> where T: class, IEntity, new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        T Add(T entity);
        T Update(T entity);
        bool Delete(T entity);
    }
}
