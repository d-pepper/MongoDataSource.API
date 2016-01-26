using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MongoDataSource.DAL
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IList<TEntity> GetAll();
    }

    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
