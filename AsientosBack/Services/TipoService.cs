using AsientosBack.Interfaces;
using AsientosBack.Models;

namespace AsientosBack.Services
{
    public class TipoService : ITipoService
    {
        private readonly ITipoMovimiento repo;
        public TipoService(ITipoMovimiento repo)
        {
            this.repo = repo;
        }

        public async Task<List<ResponseTipo>> Get()
        {
            var tipos = await repo.Get();
            return tipos.Select(t => new ResponseTipo
            {
                IdTipo = t.IdTipo,
                Nombre = t.Nombre,
            }).ToList();
        }
    }
}
