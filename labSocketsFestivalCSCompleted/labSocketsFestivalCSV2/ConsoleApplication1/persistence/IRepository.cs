using System.Collections.Generic;
using model;

namespace persistence
{
    public interface IRepository<ID,E> where E:Entity<ID>
    {
        void Save(E entity);

        E FindOne(ID id);

        IEnumerable<E> FindAll();

        void Remove(ID id);

        void Update(ID id, E e);

    }
}