using GestionTI.model.proc;
using GestionTI.util.Request;
using GestionTI.util.Respuesta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionTI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public Response login([FromBody] Req_Login login)
        {
            Response res = Mo_Login.Login(login);
            return res;
        }
    }
}
