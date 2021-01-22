using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Vote_BE.Models
{
    public class Eleccion
    {
        public int fk_TipoPropuesta { get; set; }
        public int fk_Sufragante { get; set; }
    }
}
