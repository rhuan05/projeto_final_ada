using projeto_modulo4.Repository;
using Microsoft.AspNetCore.Mvc;

namespace projeto_modulo4.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ReservaController : Controller
    {

        private ReservaRepository _repository { get; set; }

        public ReservaController()
        {
            _repository = new ReservaRepository();
        }

        //Comprar ingresso

        //Editar ingresso

        //Consultando pessoas
        [HttpGet("consultar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<EventosRepository>> ConsultaPersonTitle(string nome, string tituloEvento)
        {
            return Ok(_repository.ConsultaPersonTitle(nome, tituloEvento));
        }

        //Deletar ingresso
        [HttpDelete("deletar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Deletar(int idReserva)
        {
            return Ok(_repository.Deletar(idReserva));
        }

    }
}
