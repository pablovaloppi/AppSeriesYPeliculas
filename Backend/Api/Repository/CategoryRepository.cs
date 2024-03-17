using Contracts;
using Entities.Models;
using Entities.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : RepositoryBase<Categoria>, ICategoryRepository
    {

        public CategoryRepository( SitioSeriesConctext sitioSeriesConctext ) : base( sitioSeriesConctext ) {
        }
        public void CreateCategory( Categoria entity ) {
            Create( entity );
        }

        public void DeleteCategory( Categoria entity ) {
            Delete( entity );
        }

        public PagedList<Categoria> GetAll( CategoryParameters parameters ) {
            return PagedList<Categoria>.ToPagedList( FindAll(), parameters.PageNumber, parameters.PageSize );
        }

        public Categoria GetCategoryById( int categoryId ) {
            return FindByCondition( category => category.Id == categoryId ).FirstOrDefault();
        }

        public void UpdateCategory( Categoria entity ) {
            Update( entity );
        }
    }
}
