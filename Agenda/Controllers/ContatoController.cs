using Agenda.Domain;
using Agenda.Domain.Interfaces;
using Agenda.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _ContatosService;
        public ContatoController(IContatoService contatosService)
        {
            this._ContatosService = contatosService;
        }

        [HttpGet]
        [Route("contato")]
        public IActionResult GetList()
        {
            var listaContatos = _ContatosService.BuscarContatos();
            if(listaContatos.Count == 0) return NotFound();
            return Ok(listaContatos);
        }

        [HttpGet]
        [Route("contato/{id}")]
        public IActionResult Get(int id)
        {
            var contato = _ContatosService.BuscarContato(id);
            if(contato == null) return NotFound();
            return Ok(contato);
        }

        [HttpPost]
        [Route("contato")]
        public IActionResult Post([FromBody] Contato model)
        {
            if(!ModelState.IsValid) return BadRequest();

            var retorno = _ContatosService.CriarContato(model);
            return Ok(new
            {
                message = retorno
            });
        }

        [HttpDelete]
        [Route("contato/{id}")]
        public IActionResult Delete(int id)
        {
            var retorno = _ContatosService.DeletarContato(id);
            
            if (retorno == false)
            {
                return NotFound();
            }
            else
            {
                return Ok(new
                {
                    message = "Contato deletado com sucesso!"
                });
            }
        }

        [HttpPut]
        [Route("contato/{id}")]
        public IActionResult Put(int id, [FromBody] ContatoUpdateViewModel model)
        {
            var retorno = _ContatosService.EditarContato(id, model);
            if(retorno == false)
            {
                return NotFound();
            }
            else
            {
                return Ok(new
            {
                message = "Contato com id " + id + " atualizado com sucesso!"
            });
            }

            
        }
    }
}