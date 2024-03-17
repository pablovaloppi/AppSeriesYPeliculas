using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public  class PaisRepository : RepositoryBase<Pais>, IPaisRepository
    {
        public PaisRepository( SitioSeriesConctext sitioSeriesConctext ) : base( sitioSeriesConctext ) {
        }

        public IEnumerable<Pais> GetAll() {
            return FindAll().ToList<Pais>();
        }
    }
}
