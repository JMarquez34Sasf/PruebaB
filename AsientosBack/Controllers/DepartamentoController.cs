using AsientosBack.Interfaces;
using AsientosBack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsientosBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService service;
        public DepartamentoController(IDepartamentoService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseDepartamento>>> GetDepartamentos()
        {
            var departamentos = await service.Get();
            var respuesta = new ResponseGenerico<List<ResponseDepartamento>>
            {
                Codigo = 200,
                Message = "Departamentos",
                Response = departamentos
            };
            return Ok(respuesta);
        }
    }
}
