using System.Collections.Generic;
using WebApiCore.DomainModel;

namespace WebApiCore.Repository.Repository
{
    public class RepositoryBase<T,K> :IRepository<T,K> where T : class, new() where K : struct
    {
        public virtual bool Add(T item)
        {
            using (var db=DbTool.GetDb())
            {
                db.Insert(item);
                
            }
            return true;
        }

        public dynamic AddGet(T item)
        {
            using (var db = DbTool.GetDb())
            {
                return db.Insert(item);
            }
        }

        public virtual IEnumerable<T> FindAll()
        {
            using (var db=DbTool.GetDb())
            {
                return db.GetList<T>();
            }
        }

        public virtual T FindBy(K key)
        {
            using (var db=DbTool.GetDb())
            {
                return db.Get<T>(key);
            }
        }
 

        public virtual bool Remove(T item)
        {
            using (var db=DbTool.GetDb())
            {
                return db.Delete(item);
            }
        }

        public virtual bool RemoveAll()
        {
            using (var db=DbTool.GetDb())
            {
               return db.DelteAll<T>();
            }
        }

        public virtual bool Update(T item)
        {
            using (var db = DbTool.GetDb())
            {
              return  db.Update(item);
            }
        }

        
    }
}
