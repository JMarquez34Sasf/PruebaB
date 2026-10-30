using AsientosBack.Models;

namespace AsientosBack.Interfaces
{
    public interface IAsientoService
    {
        Task<List<ResponseAsiento>> GetService();
        Task<ResponseAsiento> CreateService(CreateAsient dto);
    }
}
