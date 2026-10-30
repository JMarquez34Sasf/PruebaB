using AsientosBack.Data;
using AsientosBack.Interfaces;
using AsientosBack.Models;
using Microsoft.EntityFrameworkCore;

namespace AsientosBack.Repositories
{
    public class TipoRepository: ITipoMovimiento
    {
        private readonly AsientosDbContext context;
        public TipoRepository(AsientosDbContext context)
        {
            this.context= context;
        }

        public async Task<List<TipoMovimiento>> Get()
        {
            var tipos = await context.TipoMovimientos.ToListAsync();
            return tipos;
        }

        public async Task<TipoMovimiento> GetById(int id)
        {
            var tipo = await context.TipoMovimientos.FindAsync(id);
            if (tipo == null) return null;
            return tipo;
        }
    }
}
