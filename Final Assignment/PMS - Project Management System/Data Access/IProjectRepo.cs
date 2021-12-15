using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public interface IProjectRepo<T, ID>
    {
        void ChangeState(T e);
        void ChangeConfirmStatus(T e,T d);
    }
}
