using Microsoft.EntityFrameworkCore;
using myper.Models;
using myper.Services.DTO;
using System.Data;

namespace myper.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly ApplicationContext _context;

        public UsuarioAppService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateUser(Trabajador input)
        {
            _context.Trabajadores.Add(input);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Trabajador>> Get()
        {
            return await _context.Trabajadores.ToListAsync();
            //return await _context.SpGetUsers();
        }

        public async Task<List<Departamento>> GetDepartamentos()
        {
            return await _context.Departamento.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<List<Distrito>> GetDistritos(int idProvincia)
        {
            var distritos = await _context.Distrito
                .Where(d => d.IdProvincia == idProvincia)
                .ToListAsync();

            return distritos;
        }

        public async Task<List<Provincia>> GetProvincias(int idDepartamento)
        {
            var provincias = await _context.Provincia
                .Where(p => p.IdDepartamento == idDepartamento)
                .ToListAsync();

            return provincias;
        }

        public async Task UpdateUser(Trabajador input)
        {
            _context.Entry(input).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var trabajador = await _context.Trabajadores.FindAsync(id);
            _context.Trabajadores.Remove(trabajador);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserDto>> GetAll()
        {
            var usersDto = new List<UserDto>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_getUsersRegisters";
                command.CommandType = CommandType.StoredProcedure;

                _context.Database.OpenConnection();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var userDto = new UserDto
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TipoDocumento = reader["TipoDocumento"].ToString(),
                            NumeroDocumento = reader["NumeroDocumento"].ToString(),
                            Nombres = reader["Nombres"].ToString(),
                            Sexo = reader["Sexo"].ToString(),
                            Departamento = reader["Departamento"].ToString(),
                            Provincia = reader["Provincia"].ToString(),
                            Distrito = reader["Distrito"].ToString(),
                            // Mapear otras propiedades según sea necesario
                        };

                        usersDto.Add(userDto);
                    }
                }
            }

            return usersDto;
        }
    }
}
