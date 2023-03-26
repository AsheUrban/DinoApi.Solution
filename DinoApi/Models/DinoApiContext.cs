using Microsoft.EntityFrameworkCore;

namespace DinoApi.Models
{
  public class DinoApiContext : DbContext
  {
    public DbSet<Animal> Animals { get; set; }

    public DinoApiContext(DbContextOptions<DinoApiContext> options) : base(options)
    {
      
    }
  }
}