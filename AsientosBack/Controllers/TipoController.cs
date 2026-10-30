using AsientosBack.Interfaces;
using AsientosBack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsientosBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        private readonly ITipoService service;
        public TipoController(ITipoService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseTipo>>> GetTipos()
        {
            var tipos = await service.Get();
            var respuesta = new ResponseGenerico<List<ResponseTipo>>
            {
                Codigo = 200,
                Message = " Tipos",
                Response = tipos
            };
            return Ok(respuesta);
        }
    }
}
