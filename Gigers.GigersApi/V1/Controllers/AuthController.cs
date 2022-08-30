using Fit.HealthCareApi.Application.Intefaces;
using Fit.HealthCareApi.Application.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit.HealthCareApi.V1.Controllers
{
    [Route("api/conta/")]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(INotificador notificador,
                              SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager) : base(notificador) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(RegisterUserViewModel registrarUsuario)
        {
            if (!ModelState.IsValid) 
                return Ok(new Exception("Modelo de registro não é válido"));

            IdentityUser _user = new IdentityUser
            {
                Email = registrarUsuario.Email,
                UserName = registrarUsuario.Email,
                EmailConfirmed = true
            };

            var _resultado = await _userManager.CreateAsync(_user, registrarUsuario.Senha);

            if (_resultado.Succeeded)
            {
                await _signInManager.SignInAsync(_user, false);
                return Ok(registrarUsuario);
            }

            foreach (var erro in _resultado.Errors)
            {
                NotificarErro(erro.Description);
            }

            return Ok(registrarUsuario);
        }

        [HttpPost("entrar")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUsuario)
        {
            if (!ModelState.IsValid)
                return Ok(new Exception("Modelo de registro não é válido"));

            var _resultado = await _signInManager.PasswordSignInAsync(loginUsuario.Email, loginUsuario.Senha, false, false);

            if (_resultado.Succeeded)
                return Ok(loginUsuario);

            NotificarErro("Usuário ou senha incorreto");

            return Ok(loginUsuario);
        }
    }
}
