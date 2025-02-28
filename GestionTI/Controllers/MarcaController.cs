using GestionTI.model.proc;
using GestionTI.util.Request;
using GestionTI.util.Respuesta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionTI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        [HttpPost]
        [Route("IngresoMarca")]
        public Response IngresoUsuario([FromBody] Req_Marca marca)
        {
            Response res = Mo_Marca.IngresoMarca(marca);
            return res;
        }
    }
}
