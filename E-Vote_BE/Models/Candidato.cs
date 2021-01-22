using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Vote_BE.Models
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Nacimiento { get; set; }
        public string Email { get; set; }
        public string fk_TipoDoc { get; set; }
        public string Identificacion { get; set; }
        public string Foto { get; set; }
    }
}
