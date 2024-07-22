// // Cuida das tratativas de conexão com o banco de dados.
// using System.Data.SqlClient;
// using Microsoft.Data.SqlClient;
// using Exo.WebApi.Models;
// using Microsoft.EntityFrameworkCore;

// namespace Exo.WebApi.Contexts
// {
//     public class ExoContext : DbContext
//     {
//         public ExoContext()
//         {
//         }

//         public ExoContext(DbContextOptions<ExoContext> options) : base(options)
//         {
//         }

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
//                 optionsBuilder.UseSqlServer("User ID=sa;Password=flamengo;Server=localhost;Database=ExoApi;Trusted_Connection=False;");
//             }
//         }

//         public DbSet<Projeto> Projetos { get; set; }
//     }
// }


using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Exo.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo.WebApi.Contexts
{
    public class ExoContext : DbContext
    {
        public ExoContext()
        {
        }

        public ExoContext(DbContextOptions<ExoContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"User ID=sa;Password=flamengo;Server=DIEGOP33\SQLEXPRESS;Database=ExoApi;Trusted_Connection=False;TrustServerCertificate=True;");
            }
        }

        public DbSet<Projeto> Projetos { get; set; }
    }
}
