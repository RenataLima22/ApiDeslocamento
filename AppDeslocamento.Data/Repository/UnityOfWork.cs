using AppDeslocamento.Data.Context;
using AppDeslocamento.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppDeslocamento.Data.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private Dictionary<Type, object> _repositories;

        public UnityOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> CommitAsync()
        {
            var result = await _applicationDbContext.SaveChangesAsync();

            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            _repositories ??= new Dictionary<Type, object>();

            var type = typeof(TEntity);


            if (_repositories.ContainsKey(type))
            {
                return (IBaseRepository<TEntity>)_repositories[type];
            }

            _repositories[type] = new BaseRepository<TEntity>(_applicationDbContext);

            return (IBaseRepository<TEntity>)_repositories[type];
        }
    }
}
