using PagedList;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace EFRepository
{
    public class Repository : IRepository, IDisposable
    {
        protected DbContext Context;
        public Repository(DbContext context, bool autoDetectChangesEnabled = false, bool proxiCreationEnabled = false)
        {
            this.Context = context;
            this.Context.Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
            this.Context.Configuration.ProxyCreationEnabled = proxiCreationEnabled;
        }

        public TEntity Create<TEntity>(TEntity newEntity) where TEntity : class
        {

            TEntity Result = null;
            try
            {
                Result = Context.Set<TEntity>().Add(newEntity);
                TrySaveChanges();
            }
            //guarda un solo registro
            catch (DbEntityValidationException dbEx)
            {
                string strError = "";
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        strError += string.Format("Prperty:{0} Error{1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
            }
            return Result;
        }

        protected virtual int TrySaveChanges()
        {
            return Context.SaveChanges();
        }

        public bool Delete<TEntity>(TEntity deleteTEntity) where TEntity : class
        {
            bool Result = false;
            try
            {
                Context.Set<TEntity>().Attach(deleteTEntity);
                Context.Set<TEntity>().Remove(deleteTEntity);
                Result = TrySaveChanges() > 0;
            }
            catch (DbEntityValidationException dbEx)
            {
                string strError = "";
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        strError += string.Format("Prperty:{0} Error{1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
            }
            return Result;
        }

        public void Dispose()
        {
            if (Context != null) { Context.Dispose(); }
            throw new NotImplementedException();
        }

        public TEntity FindTEntity<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            TEntity Result = null;
            try
            {
                Result = Context.Set<TEntity>().FirstOrDefault(criteria);
            }
            catch (DbEntityValidationException dbEx)
            {
                string strError = "";
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        strError += string.Format("Prperty:{0} Error{1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
            }
            return Result;
        }

        public IEnumerable<TEntity> FindTEntitySet<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            IEnumerable<TEntity> Result = null;
            try
            {
                Result = Context.Set<TEntity>().Where(criteria).ToList();
            }
            catch (DbEntityValidationException dbEx)
            {
                string strError = "";
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        strError += string.Format("Prperty:{0} Error{1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
            }
            return Result;
        }

        public IPagedList<TEntity> FindTEntitySetPage<TEntity>(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, string>> order, int page, int pageSize) where TEntity : class
        {
            PagedList<TEntity> Result = null;
            try
            {
                var registrosActuales = Context.Set<TEntity>().Where(criteria).OrderBy(order).Select(p => p).ToPagedList(page, pageSize);
                Result = (PagedList<TEntity>)Convert.ChangeType(registrosActuales, typeof(PagedList<TEntity>));
            }
            catch (DbEntityValidationException dbEx)
            {
                string strError = "";
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        strError += string.Format("Prperty:{0} Error{1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
            }
            return Result;
        }

        public bool update<TEntity>(TEntity updateTEntity) where TEntity : class
        {
            bool Result = false;
            try
            {
                Context.Set<TEntity>().Attach(updateTEntity);
                Context.Entry<TEntity>(updateTEntity).State = EntityState.Modified;
                Result = TrySaveChanges() > 0;
            }
            catch (DbEntityValidationException dbEx)
            {
                string strError = "";
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        strError += string.Format("Prperty:{0} Error{1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
            }
            return Result;
        }
    }

}
