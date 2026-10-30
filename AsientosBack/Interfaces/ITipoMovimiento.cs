using AsientosBack.Models;

namespace AsientosBack.Interfaces
{
    public interface ITipoMovimiento
    {
        Task<List<TipoMovimiento>> Get();
        Task<TipoMovimiento> GetById(int id);
    }
}
