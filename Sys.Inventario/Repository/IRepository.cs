using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PagedList;

namespace Repository
{
    public interface IRepository: IDisposable
    {
        //una firma Repository

        //reutilizamos este codigo para acceso a datos

        //metodo para crear 
        TEntity Create<TEntity> (TEntity newEntity) where TEntity : class;

        //metodo para update 
        bool update<TEntity>(TEntity updateTEntity) where TEntity: class;

        //metodo para Delete
        bool Delete<TEntity>(TEntity deleteTEntity) where TEntity : class;

        //regresar una fila con un select
        TEntity FindTEntity<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;

        //listado de entidades cuando se este buscando mas de un registro
        IEnumerable<TEntity> FindTEntitySet<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;

        //regresa un resultado paginado (pageSize cantidad de registroa devolver)
        IPagedList<TEntity> FindTEntitySetPage<TEntity>(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, string>> order, int page, int pageSize) where TEntity : class;



    }
}
