using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDataSource.DAL
{
    interface IRepository<TEntity>
    {
        IList<TEntity>
    }
}
