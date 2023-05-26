using lab3.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.repository
{
    public interface IRepository<ID, E> where E : Entity<ID>
    {
        E Find(ID id);

        IEnumerable<E> GetAll();

        E Save(E entity);

        E Delete(E entity);

        E Update(E entity);

    }
}
