using AsientosBack.Data;
using AsientosBack.Interfaces;
using AsientosBack.Models;
using Microsoft.EntityFrameworkCore;

namespace AsientosBack.Repositories
{
    public class DepartamentoRepository : IDepartamento
    {
        private readonly AsientosDbContext context;
        public DepartamentoRepository(AsientosDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> Get()
        {
            var departamentos = await context.Departamentos.ToListAsync();
            return departamentos;
        }

        public async Task<Departamento?> GetById(int id)
        {
            var departamento = await context.Departamentos.FindAsync(id);
            if (departamento == null) return null;
            return departamento;
        }
    }
}
