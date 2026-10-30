using AsientosBack.Data;
using AsientosBack.Interfaces;
using AsientosBack.Models;
using Microsoft.EntityFrameworkCore;

namespace AsientosBack.Repositories
{
    public class AsientoRepository: IAsiento
    {
        private readonly AsientosDbContext context;
        public AsientoRepository(AsientosDbContext context)
        {
            this.context = context;
        }

        public async Task<Asiento> Create(Asiento asiento)
        {
            context.Asientos.Add(asiento);
            await context.SaveChangesAsync();
            return asiento;
        }

        public async Task<List<Asiento>> Get()
        {
            var asientos = await context.Asientos.Include(d => d.IdDepartamentoNavigation).ToListAsync();
            return asientos;
        }
    }
}
