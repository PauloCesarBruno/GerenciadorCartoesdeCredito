using Microsoft.EntityFrameworkCore;

namespace GerenciadorCartoesCredito.Models
{
    public class Contexto : DbContext
    {
    public DbSet<Cartao> Cartoes { get; set; }

    public DbSet <Gasto> Gastos { get; set; }

    public Contexto(DbContextOptions<Contexto> options) : base (options){ }
    
    }
}