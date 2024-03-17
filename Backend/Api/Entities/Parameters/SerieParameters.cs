using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Parameters
{
    public class SerieParameters :QueryStringParameters
    {
        public uint CategoriaId { get; set; } = 0;
    }
}
