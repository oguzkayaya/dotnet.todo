using Microsoft.EntityFrameworkCore;
using dotnetMvc.Models;


namespace dotnetMvc.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<ToDo> ToDoList { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
  }
}