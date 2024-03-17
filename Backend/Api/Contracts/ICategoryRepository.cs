using Entities.Models;
using Entities.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICategoryRepository
    {
        PagedList<Categoria> GetAll( CategoryParameters parameters);
        Categoria GetCategoryById( int id );

        void CreateCategory( Categoria categoria );

        void DeleteCategory( Categoria entity );
    }
}
