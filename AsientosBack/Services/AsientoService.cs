using AsientosBack.Interfaces;
using AsientosBack.Models;

namespace AsientosBack.Services
{
    public class AsientoService :IAsientoService
    {
        private readonly IAsiento repo;
        private readonly IDepartamento repoDep;

        public AsientoService(IAsiento repo, IDepartamento repoDep)
        {
            this.repo = repo;
            this.repoDep = repoDep;
        }

        public async Task<ResponseAsiento> CreateService(CreateAsient dto)
        {
            var departamento = await repoDep.GetById(dto.IdDepartamento);
            if (departamento == null) throw new ArgumentException("Departamento no existe");
            var asiento = new Asiento
            {
                IdDepartamento = dto.IdDepartamento,
                Descripcion = dto.Descripcion,
                FechaAsiento = dto.FechaAsiento,
                IdMovimiento = dto.IdMovimiento
            };
            var asientoCreado = await repo.Create(asiento);
            return new ResponseAsiento
            {
                IdAsiento = asientoCreado.IdAsiento,
                IdMovimiento = asientoCreado.IdMovimiento,
                Departamento = asientoCreado.IdDepartamentoNavigation.Nombre,
                Descripcion = asientoCreado.Descripcion,
                FechaAsiento = asientoCreado.FechaAsiento
            };
        }

        public async Task<List<ResponseAsiento>> GetService()
        {
            var asientos = await repo.Get();
            return asientos.Select(a => new ResponseAsiento
            {
                IdAsiento = a.IdAsiento,
                IdMovimiento = a.IdMovimiento,
                Departamento = a.IdDepartamentoNavigation.Nombre,
                Descripcion = a.Descripcion,
                FechaAsiento = a.FechaAsiento
            }).ToList();
        }
    }
}
