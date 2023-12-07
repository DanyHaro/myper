using Microsoft.AspNetCore.Mvc;
using myper.Models;
using myper.Services;

namespace myper.Controllers
{
    [Route("api/usuario")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppService _usuarioService;

        public UsuarioController(IUsuarioAppService usuarioService)
        {
            _usuarioService= usuarioService;
        }

        [HttpPost]
        [Route("/create")]
        public async Task<IActionResult> Create(Trabajador input)
        {
            await _usuarioService.CreateUser(input);
            return Ok(input);
        }

        [HttpGet]
        [Route("/Get")]
        public async Task<IActionResult> Get()
        {
            var users = await _usuarioService.Get();
            if (users == null)
            {
                return Ok();
            }

            return Ok(users);
        }

        [HttpGet]
        [Route("/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _usuarioService.GetAll();
            if (users.Count < 0 || users == null)
            {
                return Ok();
            }

            return Ok(users);
        }

        [HttpGet]
        [Route("/GetDepartamento")]
        public async Task<IActionResult> GetDepartamento()
        {
            var departamentos = await _usuarioService.GetDepartamentos();
            if (departamentos == null)
            {
                return Ok();
            }

            return Ok(departamentos);
        }

        [HttpGet]
        [Route("/GetProvincias")]
        public async Task<IActionResult> GetProvincias(int idDepartamento)
        {
            var provincia = await _usuarioService.GetProvincias(idDepartamento);
            if (provincia == null)
            {
                return Ok();
            }

            return Ok(provincia);
        }

        [HttpGet]
        [Route("/GetDistritos")]
        public async Task<IActionResult> GetDistritos(int idProvincia)
        {
            var distritos = await _usuarioService.GetDistritos(idProvincia);
            if (distritos == null)
            {
                return Ok();
            }

            return Ok(distritos);
        }

        [HttpPut]
        [Route("/update")]
        public async Task<IActionResult> Update(Trabajador input)
        {
            await _usuarioService.UpdateUser(input);
            return Ok(input);
        }

        [HttpDelete]
        [Route("/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _usuarioService.DeleteUser(id);
                return Ok(new
                {
                    Mensaje = "usuario eliminado"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
