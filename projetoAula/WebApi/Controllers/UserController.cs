using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.ServiceInterfaces;
using SecureIdentity.Password;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.DTOs;
using WebApi.Extensions;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(
                ITokenService tokenService,
                IUserRepository userRepository,
                IUnitOfWork unitOfWork
        )
        {
            this._tokenService = tokenService;
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpPost("v1/users/account/")]
        public async Task<IActionResult> Post([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultDTO<string>(ModelState.GetErrors()));

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Slug = model.Email.Replace("@", "-").Replace(".", "-")
            };

            //var password = PasswordGenerator.Generate(25);
            user.Password = PasswordHasher.Hash(model.Password);

            try
            {
                _userRepository.Save(user);
                await _unitOfWork.CommitAsync();

                //_emailService.Send(
                //    user.Name,
                //    user.Email,
                //    "Bem vindo",
                //    $"Sua senha é <strong>{password}</strong>",
                //    "Equipe DedaMaia",
                //    "darochasantos.diego@gmail.com");

                var userDTO = new UserDTO()
                {
                    Id = user.Id,
                    Email = user.Email
                };

                return Created($"v1/users/account/{userDTO.Id}", new ResultDTO<dynamic>(new
                {
                    user = userDTO.Id, userDTO.Email
                }));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultDTO<User>("09XE9 - Este e-mail já está cadastrado"));
            }
            catch
            {
                return StatusCode(500, new ResultDTO<User>("09X10 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/users/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultDTO<string>(ModelState.GetErrors()));

            var user = await _userRepository.GetByEmailAsync(model.Email);

            if (user == null)
                return StatusCode(401, new ResultDTO<string>("Usuário ou senha inválidos"));

            if (!PasswordHasher.Verify(user.Password, model.Password))
                return StatusCode(401, new ResultDTO<string>("Usuário ou senha inválidos"));

            try
            {
                var token = _tokenService.GenerateToken(user);
                return Ok(new ResultDTO<string>(token, errors: null));
            }
            catch
            {
                return StatusCode(500, new ResultDTO<User>("09X04 - Falha interna no servidor"));
            }
        }
    }
}