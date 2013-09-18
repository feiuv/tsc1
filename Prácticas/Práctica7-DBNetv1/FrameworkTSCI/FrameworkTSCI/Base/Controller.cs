using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkTSCI.Base
{
    public interface Controller<E>
    {
        void Add(E e);
        void Delete(E e);
        List<E> GetAll();
        E GetById(int id);
    }
}
