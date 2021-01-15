using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class clieteDTO
    {
        public int clienteId { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fecha { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public string email { get; set; }
    }
}
