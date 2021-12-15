using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    interface IRepository<T,ID>
    {
        void Add(T e);
        void Edit(T e);
        void Delete(ID id);
        List<T> Get();
        T Get(ID id);
    }
}
