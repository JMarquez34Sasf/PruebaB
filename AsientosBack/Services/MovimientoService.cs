using AsientosBack.Interfaces;
using AsientosBack.Models;

namespace AsientosBack.Services
{
    public class MovimientoService: IMovimientoService
    {
        private readonly IMovimiento repo;
        private readonly ITipoMovimiento repoTipo;
        public MovimientoService(IMovimiento repo, ITipoMovimiento repoTipo)
        {
            this.repo = repo;
            this.repoTipo = repoTipo;
        }

        public async Task<ResponseMovimiento> CreateService(CreateMomiento dto)
        {
            var tipo = await repoTipo.GetById(dto.IdTipo);
            if (tipo == null) throw new ArgumentNullException("Ingrese un tipo Valido");
            var movimiento = new Movimiento
            {
                Ncuenta = dto.Ncuenta,
                Descripcion = dto.Descripcion,
                Valor = dto.Valor,
                IdTipo = dto.IdTipo,
            };
            var moviCreado = await repo.Create(movimiento);
            return new ResponseMovimiento
            {
                IdMovimiento = moviCreado.IdMovimiento,
                Ncuenta = moviCreado.Ncuenta,
                Descripcion = moviCreado.Descripcion,
                Fecha = moviCreado.Fecha,
                Valor = moviCreado.Valor,
                Tipo = moviCreado.IdTipoNavigation.Nombre
            };
        }

        public async Task<List<ResponseMovimiento>> GetService()
        {
            var movimientos = await repo.Get();
            return movimientos.Select(m => new ResponseMovimiento
            {
                IdMovimiento = m.IdMovimiento,
                Ncuenta = m.Ncuenta,
                Descripcion = m.Descripcion,
                Fecha = m.Fecha,
                Valor = m.Valor,
                Tipo = m.IdTipoNavigation.Nombre
            }).ToList();
        }
    }
}
