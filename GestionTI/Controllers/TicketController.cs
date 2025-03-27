using GestionTI.model.proc;
using GestionTI.util.Request;
using GestionTI.util.Respuesta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionTI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        [HttpPost]
        [Route("IngresoTicket")]
        public Response IngresoTicket([FromBody] Req_Ticket ticket)
        {
            Response res = Mo_Ticket.IngresoTicket(ticket);
            return res;
        }
    }
}
