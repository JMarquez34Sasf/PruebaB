using AsientosBack.Models;

namespace AsientosBack.Interfaces
{
    public interface ITipoService
    {
        Task<List<ResponseTipo>> Get();
    }
}
