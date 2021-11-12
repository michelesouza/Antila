using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interface
{
    interface IObjDataBase<T>
    {
        IList<T> Get(T obj);

        T SetObject(IDataReader dr);
    }
}
