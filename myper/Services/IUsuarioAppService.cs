using myper.Models;
using myper.Services.DTO;

namespace myper.Services
{
    public interface IUsuarioAppService
    {
        Task CreateUser(Trabajador input);
        Task<List<Trabajador>> Get();
        Task<List<UserDto>> GetAll();
        Task<List<Departamento>> GetDepartamentos();
        Task<List<Provincia>> GetProvincias(int idDepartamento);
        Task<List<Distrito>> GetDistritos(int idProvincia);
        Task UpdateUser(Trabajador input);
        Task DeleteUser(int id);
    }
}
