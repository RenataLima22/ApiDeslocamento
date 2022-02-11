using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Domain.Interfaces
{
    public interface IUnityOfWork : IDisposable
    {
        IBaseRepository<TEntity> GetRepository<TEntity>()
           where TEntity : class;

        Task<int> CommitAsync();
    }
}
