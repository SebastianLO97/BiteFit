using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiteFit.Models
{
    public class User
    { 
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string apellidoPat { get; set; }
        public string apellidoMat { get; set; }
        public int genero { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string pais { get; set; }
        public string estado { get; set; }
        public string municipio { get; set; }
        public string fraccionamiento { get; set; }
        public string calle { get; set; }
        public int numeroInterior { get; set; }
        public int numeroExterior { get; set; }
        public int cp { get; set; }
    }
}
