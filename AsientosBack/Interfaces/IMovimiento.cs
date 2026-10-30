using AsientosBack.Models;

namespace AsientosBack.Interfaces
{
    public interface IMovimiento
    {
        Task<Movimiento> Create(Movimiento movimiento);
        Task<List<Movimiento>> Get();
        Task<Movimiento> GetById(int id);
    }
}
