using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionTI.util.Request
{
    public class Req_Activo
    {
        public Trankey _trankey { get; set; }
        public string nombre { get; set; }
        public int cod_tipo_acti {  get; set; }
        public int cod_modelo { get; set; }
        public string serie { get; set; }
        public int cod_estado { get; set; }
        public string fech_adquisicion {  get; set; }
        public int cod_proveedor { get; set; }
        public int cod_usua_creacion { get; set; }

   
    }
}
