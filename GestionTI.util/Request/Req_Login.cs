using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTI.util.Request
{
    public class Req_Login
    {
        public Trankey _trankey { get; set; }
        public string email { get; set; }
        public string contrasena { get; set; }
    }
}
