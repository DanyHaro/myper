using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myper.Models;
using myper.Services.DTO;

namespace myper
{
    public class ApplicationContext : DbContext
    {
        private readonly IMapper _mapper;
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IMapper mapper) : base(options)
        {
            _mapper= mapper;
        }

        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Distrito> Distrito { get; set; }


        //public async Task<List<UserDto>> SpGetUsers()
        //{
        //    List<Trabajador> trabajador = await Trabajadores.FromSqlRaw("EXEC sp_getUsersRegisters").ToListAsync();
        //    List<UserDto> user = _mapper.Map<List<UserDto>>(trabajador);
        //    return user;
        //}
    }
}
