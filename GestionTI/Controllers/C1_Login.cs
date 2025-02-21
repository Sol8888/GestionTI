using GestionTI.model.proc;
using GestionTI.util.Request;
using GestionTI.util.Respuesta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GestionTI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C1_Login : ControllerBase
    {
        [HttpPost]
        [Route("Hellow")]
        public Response m1_valida_ingreso([FromBody] P1_Holita login_usuario)
        {
            Response res = Hola.validaIngreso(login_usuario);
            return res;
        }

    }
}
