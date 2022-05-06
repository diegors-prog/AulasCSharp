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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService customerService)
        {
            this._service = customerService;
        }

        [HttpGet("v1/customers")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var customers = await _service.GetAllCustomersAsync();
                return Ok(new ResultViewModel<IList<Customer>>(customers));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<IList<Customer>>("05XE2 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/customers/{id:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
        {
            try
            {
                var customer = await _service.SearchCustomerAsync(id);

                if (customer == null)
                    return NotFound(new ResultViewModel<Customer>("Conteúdo não encontrado"));
                else
                    return Ok(new ResultViewModel<Customer>(customer));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Customer>("05XE3 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/customers")]
        public async Task<IActionResult> PostAsync([FromBody] EditorCustomerViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel<Customer>(ModelState.GetErrors()));

                var newCustomer = new Customer
                {
                    Name = model.Name,
                    Phone = model.Phone,
                    Address = model.Address
                };

                var retorno = await _service.AddCustomerAsync(newCustomer);

                return Created($"v1/customers/{newCustomer.Id}", new ResultViewModel<Customer>(newCustomer));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Customer>("05XE9 - Não foi possível incluir o cliente"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Customer>("05X10 - Falha interna no servidor"));
            }

        }

        [HttpPut("v1/customers/{id:long}")]
        public async Task<IActionResult> PutAsync([FromRoute] long id, [FromBody] EditorCustomerViewModel model)
        {
            try
            {
                var customer = await _service.SearchCustomerAsync(id);

                if (customer == null)
                    return NotFound(new ResultViewModel<Customer>("Conteúdo não encontrado"));

                customer.Name = model.Name;
                customer.Phone = model.Phone;
                customer.Address = model.Address;

                var edited = await _service.EditCustomer(customer);

                return Ok(new ResultViewModel<Customer>(customer));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Customer>("05XF7 - Não foi possível atualizar o cliente"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Customer>("05X11 - Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/customers/{id:long}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            try
            {
                var customerDelete = await _service.RemoveCustomerAsync(id);

                if (customerDelete == false)
                    return NotFound(new ResultViewModel<Customer>("Conteúdo não encontrado"));
                else
                    return Ok(new ResultViewModel<long>(id));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Customer>("05XF1 - Não foi possível deletar o cliente"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Customer>("05X12 - Falha interna no servidor"));
            }
        }
    }
}
