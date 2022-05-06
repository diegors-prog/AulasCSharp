using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Controllers.ViewModels;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces.ServiceInterfaces;
using WebApi.Extensions;

namespace WebApi.Controllers
{
    [ApiController]
    public class ChargeController : ControllerBase
    {
        private readonly IChargeService _service;

        public ChargeController(IChargeService chargeService)
        {
            this._service = chargeService;
        }

        [HttpGet("v1/charges")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var charges = await _service.GetAllChargesAsync();
                return Ok(new ResultViewModel<IList<Charge>>(charges));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<IList<Charge>>("07XE2 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/charges/{id:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
        {
            try
            {
                var charge = await _service.SearchChargeAsync(id);

                if (charge == null)
                    return NotFound(new ResultViewModel<Charge>("Conteúdo não encontrado"));
                else
                    return Ok(new ResultViewModel<Charge>(charge));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Charge>("07XE3 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/charges")]
        public async Task<IActionResult> PostAsync([FromBody] CreateChargeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel<Charge>(ModelState.GetErrors()));

                var newCharge = new Charge
                {
                    DueDate = Convert.ToDateTime(model.DueDate),
                    AmountCharge = model.AmountCharge,
                    CustomerId = model.CustomerId
                };
                var retorno = await _service.AddChargeAsync(newCharge);

                return Created($"v1/charges/{newCharge.Id}", new ResultViewModel<Charge>(newCharge));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Charge>("07XF9 - Não foi possível incluir a cobrança"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Charge>("07X10 - Falha interna no servidor"));
            }
        }

        [HttpPatch("v1/charges/{id:long}")]
        public async Task<IActionResult> PutAsync([FromRoute] long id)
        {
            try
            {
                var chargePaid = await _service.PayChargeAsync(id);

                if (chargePaid == null)
                    return NotFound(new ResultViewModel<Charge>("Conteúdo não encontrado"));
                else
                    return Ok(new ResultViewModel<Charge>(chargePaid));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Charge>("07XF7 - Não foi possível atualizar a cobrança"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Charge>("07X11 - Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/charges/{id:long}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            try
            {
                var chargeDelete = await _service.RemoveChargeAsync(id);

                if (chargeDelete == false)
                    return NotFound(new ResultViewModel<Charge>("Conteúdo não encontrado"));
                else
                    return Ok(new ResultViewModel<long>(id));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Charge>("07XF1 - Não foi possível deletar a cobrança"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Charge>("07X12 - Falha interna no servidor"));
            }
        }
    }
}
