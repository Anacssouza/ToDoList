using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class BancoContext : DbContext 
    {

        public BancoContext(DbContextOptions<BancoContext> options)  : base(options)
        {

        }

        public DbSet<AtividadesModel> Atividades { get; set; }


    }
}
