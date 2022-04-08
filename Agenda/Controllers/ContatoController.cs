using System.Threading.Tasks;
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
        private readonly IContatoRepository _ContatosRepository;
        public ContatoController(IContatoRepository contatosRepository)
        {
            this._ContatosRepository = contatosRepository;
        }

        [HttpGet]
        [Route("contato")]
        public IActionResult GetList()
        {
            var listaContatos = _ContatosRepository.GetAll();
            if(listaContatos.Count == 0) return NotFound();
            return Ok(listaContatos);
        }

        [HttpGet]
        [Route("contato/{id}")]
        public IActionResult Get(int id)
        {
            var contato = _ContatosRepository.GetById(id);
            if(contato == null) return NotFound();
            return Ok(contato);
        }

        [HttpPost]
        [Route("contato")]
        public IActionResult Post([FromBody] Contato model)
        {
            if(!ModelState.IsValid) return BadRequest();

            _ContatosRepository.Save(model);
            return Ok(new
            {
                message = "Contato " + model.Nome + " foi adicionado com sucesso!"
            });
        }

        [HttpDelete]
        [Route("contato/{id}")]
        public IActionResult Delete(int id)
        {
            var contato = _ContatosRepository.GetById(id);
            if(contato == null) return NotFound();

            _ContatosRepository.Delete(contato);
            return Ok(new
            {
                message = "Cliente deletado com sucesso!"
            });
        }

        [HttpPut]
        [Route("contato/{id}")]
        public IActionResult Put(int id, [FromBody] ContatoUpdateViewModel model)
        {
            var contato = _ContatosRepository.GetById(id);
            if(contato == null) return NotFound();

            contato.Nome = model.Nome;
            contato.Telefone = model.Telefone;

            _ContatosRepository.Update(contato);
            return Ok(new
            {
                message = "Contato com id " + id + " atualizado com sucesso!"
            });
        }
    }
}