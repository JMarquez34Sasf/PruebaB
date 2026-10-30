using AsientosBack.Models;

namespace AsientosBack.Interfaces
{
    public interface IDepartamento
    {
        Task<List<Departamento>> Get();
        Task<Departamento?> GetById(int id);
    }
}
