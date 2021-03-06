﻿using System.Linq;
using System.Threading.Tasks;
using BasicInfrastructure.Persistence;

namespace BasicInfrastructure.Service
{
    public class BaseService<T> : ReadOnlyService<T>, IService<T>
        where T : Entity
    {

        public BaseService(IRepository<T> repository) : base(repository)
        {
        }

        public virtual async Task<T> Add(T entity)
        {
            OnBeforeAdd(entity);
            entity = Repository.Add(entity);
            OnAfterAdd(entity);
            var r = entity;
            return r;
        }

        public virtual async Task<T> Update(T entity, int? id = null)
        {
            if (id.HasValue)
                entity.Id = id.Value;

            OnBeforeUpdate(entity);
            entity = Repository.Update(entity);
            OnAfterUpdate(entity);
            var r = entity;
            return r;
        }

        public virtual async Task<bool> Delete(T entity)
        {
            OnBeforeDelete(entity);
            var r = Repository.Delete(entity);
            OnAfterDelete(entity);
            return r;
        }

        public virtual async Task<bool> Delete(int id)
        {
            return Repository.Delete(id);
        }

        protected virtual void OnBeforeAdd(T entity)
        {
            BeforeAdd?.Invoke(entity);
        }

        protected virtual void OnAfterAdd(T entity)
        {
            AfterAdd?.Invoke(entity);
        }

        protected virtual void OnBeforeUpdate(T entity)
        {
            BeforeUpdate?.Invoke(entity);
        }

        protected virtual void OnAfterUpdate(T entity)
        {
            AfterUpdate?.Invoke(entity);
        }

        protected virtual void OnBeforeDelete(T entity)
        {
            BeforeDelete?.Invoke(entity);
        }

        protected virtual void OnAfterDelete(T entity)
        {
            AfterDelete?.Invoke(entity);
        }

        protected event AfterHandler AfterAdd;
        protected event AfterHandler AfterDelete;
        protected event AfterHandler AfterUpdate;
        protected event BeforeHandler BeforeAdd;
        protected event BeforeHandler BeforeDelete;
        protected event BeforeHandler BeforeUpdate;
        protected delegate void AfterHandler(T entity);
        protected delegate void BeforeHandler(T entity);
    }
}