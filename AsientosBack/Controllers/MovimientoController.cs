using AsientosBack.Interfaces;
using AsientosBack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsientosBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoService service;
        public MovimientoController(IMovimientoService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseMovimiento>> CreateMovimiento(CreateMomiento dto)
        {
            var movimiento = await service.CreateService(dto);
            var respuesta = new ResponseGenerico<ResponseMovimiento>
            {
                Codigo = 200,
                Message = "Movimiento creado",
                Response = movimiento
            };
             return Ok(respuesta);
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseMovimiento>>> GetMovimiento()
        {
            var movimientos = await service.GetService();
            var respuesta = new ResponseGenerico<List<ResponseMovimiento>>
            {
                Codigo = 200,
                Message = "Movimientos",
                Response = movimientos
            };
            return Ok(respuesta);
              
        }
    }
}
