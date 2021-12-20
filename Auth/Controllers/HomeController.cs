using Auth.Services;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth.Controllers
{
    [Route("v1/account")]
    public class HomeController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public HomeController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }




        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]Usuario model)
        { 
            var user = _usuarioRepository.GetUsuariosList();
            var logado = user.Result.Find(x => x.UserName == model.UserName && x.Password == model.Password);

            if (logado == null)
            {
                return NotFound(new { message = "Usuario ou senha invalido" });
            }

            var token = TokenService.GenerateToken(logado);
            logado.Password = "";
            return new
            {
                user = logado,
                token = token

            };
        }


        //[HttpGet]
        //[Route("anonymous")]
        //[AllowAnonymous]
        //public string Anonymous() => "Anonimo";


        //[HttpGet]
        //[Route("authenticated")]
        //[Authorize]
        //public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        //[HttpGet]
        //[Route("user")]
        //[Authorize(Roles = "user,admin")]
        //public string Employee() => "Funcionario";

        //[HttpGet]
        //[Route("admin")]
        //[Authorize(Roles = "manager")]
        //public string Manager() => "Gerente";


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var data = await _usuarioRepository.GetAll();

            return Ok(data);
        }

        [Route("nomes")]
        [HttpGet]
        public async Task<IActionResult> GetNomes()
        {
            var data = await _usuarioRepository.GetUsuarios();
            var lista = new List<string>();
            foreach (var item in data)
                lista.Add(item.UserName.ToString());

            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Post([FromBody] Usuario model)
        {
           
            if (!ModelState.IsValid)
            {
                return Ok("Erro");
            }

            try
            {
                _usuarioRepository.Add(model);
            }
            catch (Exception ex)
            {
                return Ok("ERRO.");
            }

            return Ok("Salvo !!!");
        }

        [HttpDelete]
        public async Task<ActionResult<dynamic>> Delete([FromBody] Usuario model)
        {

            if (!ModelState.IsValid)
            {
                return Ok("Erro");
            }

            try
            {
                _usuarioRepository.Delete(model);
            }
            catch (Exception ex)
            {
                return Ok("ERRO.");
            }

            return Ok("Salvo !!!");
        }
        [HttpPut]
        public async Task<ActionResult<dynamic>> Update([FromBody] Usuario model)
        {

            if (!ModelState.IsValid)
            {
                return Ok("Erro");
            }

            try
            {
                _usuarioRepository.Update(model);
            }
            catch (Exception ex)
            {
                return Ok("ERRO.");
            }

            return Ok("Salvo !!!");
        }

    }
}
