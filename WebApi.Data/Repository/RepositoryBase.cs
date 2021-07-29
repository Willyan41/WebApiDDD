using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Data.Context;
using WebApi.Domain.Entities;
using WebApi.Domain.Interface;

namespace WebApi.Data.Repository
{
    public class RepositoryBase<TEntity> : IBaseRepository<TEntity> where TEntity : EntidadeBase
    {

        protected readonly WebApiContext _webApiContext;

        public RepositoryBase(WebApiContext webApiContext)
        {
            _webApiContext = webApiContext;
        }

        public void Insert(TEntity obj)
        {
            _webApiContext.Set<TEntity>().Add(obj);
            _webApiContext.SaveChanges();
        }


        public void Update(TEntity obj)
        {
            _webApiContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _webApiContext.SaveChanges();

        }

        public void Delete(int id)
        {
            _webApiContext.Set<TEntity>().Remove(Select(id));
            _webApiContext.SaveChanges();

        }

        public IList<TEntity> Select() => _webApiContext.Set<TEntity>().ToList();

        public TEntity Select(int id) => _webApiContext.Set<TEntity>().Find(id);

      
    }
}
