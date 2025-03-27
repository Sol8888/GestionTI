using GestionTI.model.proc;
using GestionTI.util.Request;
using GestionTI.util.Respuesta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionTI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivoController : ControllerBase
    {
        [HttpPost]
        [Route("IngresoActivo")]
        public Response IngresoActivo([FromBody] Req_Activo activo)
        {
            Response res = Mo_Activo.IngresoActivo(activo);
            return res;
        }
    }
}
