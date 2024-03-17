using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected SitioSeriesConctext SitioSeriesConctext { get; set; }

        public RepositoryBase( SitioSeriesConctext sitioSeriesConctext)
        {
            SitioSeriesConctext = sitioSeriesConctext;
        }
        public IQueryable<T> FindAll() => SitioSeriesConctext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition( Expression<Func<T, bool>> expression ) =>
                    SitioSeriesConctext.Set<T>().Where( expression ).AsNoTracking();

        public void Create( T entity ) => SitioSeriesConctext.Set<T>().Add( entity );

        public void Delete( T entity ) => SitioSeriesConctext.Set<T>().Remove( entity );

        public void Update( T entity ) => SitioSeriesConctext.Set<T>().Update(entity);


    }
}