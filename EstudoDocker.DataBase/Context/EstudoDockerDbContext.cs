using EstudoDocker.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace EstudoDocker.DataBase.Context
{
    public class EstudoDockerDbContext:DbContext
    {

        // O construtor deve aceitar DbContextOptions<SeuContexto> e passá-lo para a classe base
        public EstudoDockerDbContext(DbContextOptions<EstudoDockerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pesssoa> Pessoa{ get; set; }  
    
    }
}
