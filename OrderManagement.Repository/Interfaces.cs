using System.Collections.Generic;

namespace OrderManagement.Repository
{
    public interface IReadOnlyRepository<out T>
    {
        T Get(int ID);
        IReadOnlyCollection<T> Get();
    }
    public interface IRepository<T> : IReadOnlyRepository<T>
    {
        bool Write(T entity);
        bool Delete(int ID);


    }

}
