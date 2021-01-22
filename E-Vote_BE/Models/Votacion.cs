using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Vote_BE.Models
{
    public class Votacion
    {
        public int Id { get; set; }
        public int Votante_Id { get; set; }
        public int Propuesta_Id { get; set; }
        public int Voto { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
    }
}
