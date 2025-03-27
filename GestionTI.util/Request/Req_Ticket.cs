using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionTI.util.Request
{
    public class Req_Ticket
    {
        public Trankey _trankey { get; set; }

        public int cod_activo { get; set; }
        public string estado { get; set; }
        public string prioridad { get; set; }
        public string descripcion { get; set; }
        public int cod_usua_asig {  get; set; }

        public int cod_usua_creacion { get; set; }

    }
}
