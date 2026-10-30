using AsientosBack.Models;

namespace AsientosBack.Interfaces
{
    public interface IAsiento
    {
        Task<Asiento> Create(Asiento asiento);
        Task<List<Asiento>> Get();
    }
}
