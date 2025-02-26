using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTI.util.Request
{
    public class Req_Usuario
    {
        public Trankey _trankey { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }

        public string email { get; set; }
        public string rol { get; set; }
        public string cuenta { get; set; }
        public string contrasena { get; set; }
        
        public int cod_departamento { get; set; }
        public int cod_usua_creacion { get; set; }




    }
}
