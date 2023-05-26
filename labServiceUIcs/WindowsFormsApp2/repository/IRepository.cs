using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.model;

namespace WindowsFormsApp2.repository
{
    public interface IRepository<ID, E> where E : Entity<ID>
    {
        E FindOne(ID id);

        IEnumerable<E> FindAll();

        E Save(E e);

        E Remove(ID id);

        E Update(ID id, E e);
    }
}
