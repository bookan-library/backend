using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Repository.Core
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
        new void Dispose();

        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        public IUserRepository UserRepository { get; }
    }
}
