using AsientosBack.Data;
using AsientosBack.Interfaces;
using AsientosBack.Models;
using Microsoft.EntityFrameworkCore;

namespace AsientosBack.Repositories
{
    public class MovimientoRepository : IMovimiento
    {
        private readonly AsientosDbContext context;
        public MovimientoRepository(AsientosDbContext context)
        {
            this.context = context;
        }

        public async Task<Movimiento> Create(Movimiento movimiento)
        {
            context.Movimientos.Add(movimiento);
            await context.SaveChangesAsync();
            return movimiento;
        }

        public async Task<List<Movimiento>> Get()
        {
            var movimeintos = await context.Movimientos.Include(t => t.IdTipoNavigation).ToListAsync();
            return movimeintos;
        }

        public async Task<Movimiento> GetById(int id)
        {
            var movimiento = await context.Movimientos.Include(t=>t.IdTipoNavigation).FirstOrDefaultAsync(i=>i.IdMovimiento== id);
            if (movimiento == null) return null;
            return movimiento;
        }
    }
}
