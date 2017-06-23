using Microsoft.EntityFrameworkCore;

namespace TarefaWeb.Models
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> option) : base(option)
        {

        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}