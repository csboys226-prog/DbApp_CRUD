using Microsoft.EntityFrameworkCore;
using DbApp_CRUD.Models;

namespace DbApp_CRUD.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }
    }
}