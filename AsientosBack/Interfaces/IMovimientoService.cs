using AsientosBack.Models;

namespace AsientosBack.Interfaces
{
    public interface IMovimientoService
    {
        Task<List<ResponseMovimiento>> GetService();
        Task<ResponseMovimiento> CreateService(CreateMomiento dto);
    }
}
