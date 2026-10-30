using AsientosBack.Models;

namespace AsientosBack.Interfaces
{
    public interface IDepartamentoService
    {
        Task<List<ResponseDepartamento>> Get();
    }
}
