using AsientosBack.Interfaces;
using AsientosBack.Models;

namespace AsientosBack.Services
{
    public class DepartamentoService :IDepartamentoService
    {
        private readonly IDepartamento repo;
        public DepartamentoService(IDepartamento repo)
        {
            this.repo = repo;
        }

        public async Task<List<ResponseDepartamento>> Get()
        {
            var departemento = await repo.Get();
            return departemento.Select(d => new ResponseDepartamento
            {
                IdDepartamento = d.IdDepartamento,
                Nombre = d.Nombre,
            }).ToList();
        }
    }
}
