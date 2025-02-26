using GestionTI.model.proc;
using GestionTI.util.Request;
using GestionTI.util.Respuesta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionTI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("IngresoUsuario")]
        public Response IngresoUsuario([FromBody] Req_Usuario usuario)
        {
            Response res = Mo_Usuario.IngresoUsuarios(usuario);
            return res;
        }
    }
}
