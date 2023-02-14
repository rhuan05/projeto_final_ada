using projeto_modulo4.Repository;
using Microsoft.AspNetCore.Mvc;

namespace projeto_modulo4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class EventosController : Controller
    {

        public EventosRepository _repository { get; set; }

        //Controller
        public EventosController()
        {
            _repository = new EventosRepository();
        }

        //Inserindo evento
        [HttpPost("adicionar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Eventos>> AdicionarEvento(Eventos evento)
        {

            if (!_repository.AdicionarEvento(evento))
            {
                return BadRequest();
            }

            return Ok(evento);

        }

        //Editando evento
        [HttpPut("editar/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EditarEvento([FromRoute] int id, Eventos evento)
        {
            if (!_repository.EditarEvento(evento, id))
            {
                return BadRequest();
            }

            return Ok(evento);
        }

        //Removendo evento
        [HttpDelete("deletar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletarEvento(Eventos evento, int id)
        {
            if (!_repository.DeletarEvento(evento, id) || !_repository.VerificarStatus(evento, id))
            {
                return BadRequest();
            }

            return NoContent();
        }

        //Buscando por título
        [HttpGet("busca/titulo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult BuscarPorTitulo(string titulo)
        {
            return Ok(_repository.BuscarPorTitulo(titulo));
        }

        //Buscando por local
        [HttpGet("busca/local")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult BuscarPorLocal(string local)
        {
            return Ok(_repository.BuscarPorLocal(local));
        }

        //Buscar por data
        [HttpGet("busca/data")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult BuscarPorPrecoEdata([FromBody] string data, int precoMin, int precoMax)
        {
            return Ok(_repository.BuscarPorPrecoeData(data, precoMin, precoMax));
        }

    }
}
