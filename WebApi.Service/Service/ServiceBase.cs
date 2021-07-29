using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Domain.Entities;
using WebApi.Domain.Interface;

namespace WebApi.Service.Service
{
    public class ServiceBase<TEntity> : IBaseService<TEntity> where TEntity : EntidadeBase
    {

        private readonly IBaseRepository<TEntity> _baseRepository;

        public ServiceBase(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }


        public TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validar(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(obj);
            return obj;
        }

        public void Delete(int id) => _baseRepository.Delete(id);

        public IList<TEntity> Get() => _baseRepository.Select();

        public TEntity GetById(int id) => _baseRepository.Select(id);

        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validar(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(obj);
            return obj;
        }

        private void Validar (TEntity obj, AbstractValidator<TEntity> validator)
        {
            if(obj == null)
            {
                throw new Exception("Registro não encontrado.");
                validator.ValidateAndThrow(obj);
            }
        }

    }
}
