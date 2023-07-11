using System.Collections;

namespace pro2.DB
{
    public interface IRepository <T>
    {
        Task Add (T entity);
        IEnumerable<T> GetLastTen ();
        T? Get (int id);
    }
}
