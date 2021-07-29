using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Interface
{
    public interface IBaseService<TEntity> where TEntity : EntidadeBase
    {
        TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        void Delete(int id);
        IList<TEntity> Get();
        TEntity GetById(int id);
        TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;


    }
}
