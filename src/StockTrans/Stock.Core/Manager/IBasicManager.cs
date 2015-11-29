using System.Collections.Generic;

namespace Stock.Core.Manager
{
    public interface IBasicManager<T> where T : class
    {
        T Add(T item);
        void Delete(T item);
        T GetItem(int id);
        ICollection<T> GetAll();
    }
}