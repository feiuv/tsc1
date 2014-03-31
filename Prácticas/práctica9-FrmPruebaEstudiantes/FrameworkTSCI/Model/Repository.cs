using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkTSCI.Model
{
    interface Repository<E>
    {
        void Add(E o);
        void Delete(E o);
        E GetById(int id);
        List<E> GetAll();
    }
}
