using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : EntidadeBase
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(int id);
        IList<TEntity> Select();
        TEntity Select(int id);

    }
}
