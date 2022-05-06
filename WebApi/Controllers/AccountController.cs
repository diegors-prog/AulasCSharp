using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using WebApi.Controllers.ViewModels;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces.ServiceInterfaces;
using WebApi.Extensions;

namespace WebApi.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public AccountController(
            ITokenService tokenService,
            IUserService userService,
            IEmailService emailService)
        {
            this._tokenService = tokenService;
            this._userService = userService;
            this._emailService = emailService;
        }

        [HttpPost("v1/accounts/")]
        public async Task<IActionResult> Post([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Slug = model.Email.Replace("@", "-").Replace(".", "-")
            };

            //var password = PasswordGenerator.Generate(25);
            user.PasswordHash = PasswordHasher.Hash(model.Password);

            try
            {
                var retorno = await _userService.AddUserAsync(user);

                //_emailService.Send(
                //    user.Name,
                //    user.Email,
                //    "Bem vindo",
                //    $"Sua senha é <strong>{password}</strong>",
                //    "Equipe DedaMaia",
                //    "darochasantos.diego@gmail.com");

                return Created($"v1/accounts/{user.Id}", new ResultViewModel<dynamic>(new
                {
                    user = user.Id, user.Email
                }));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Customer>("09XE9 - Este e-mail já está cadastrado"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Customer>("09X10 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/accounts/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            var user = await _userService.SearchUserByEmailAsync(model.Email);

            if (user == null)
                return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválidos"));

            if (!PasswordHasher.Verify(user.PasswordHash, model.Password))
                return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválidos"));

            try
            {
                var token = _tokenService.GenerateToken(user);
                return Ok(new ResultViewModel<string>(token, errors: null));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Customer>("09X04 - Falha interna no servidor"));
            }
        }

    }
}
