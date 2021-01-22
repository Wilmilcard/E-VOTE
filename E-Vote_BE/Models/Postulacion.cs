using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Vote_BE.Models
{
    public class Postulacion
    {
        public int Id { get; set; }
        public string Propuesta { get; set; }
        public int fk_candidato { get; set; }
        public int fk_TipoPropuesta { get; set; }
    }
}
