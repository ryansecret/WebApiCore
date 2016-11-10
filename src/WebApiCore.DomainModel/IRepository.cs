using System.Collections.Generic;

namespace WebApiCore.DomainModel
{ 
    public interface IRepository<T,TK> where T:class,new() where TK:struct 
    {
        T FindBy(TK key);

        IEnumerable<T> FindAll();

        bool Add(T item);

        dynamic AddGet(T item);

        bool Update(T item);

        bool Remove(T item);

        bool RemoveAll();
    }
}