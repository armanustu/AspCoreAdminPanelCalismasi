using BlogApi.EntityLayer;
using DataEntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.DataAccess
{
    public class Context:DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-7GJPC0B\\SQLEXPRESS;Database=MvcCoreDb;integrated security=true;TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder); 
        }
        public virtual DbSet<Employee> Employees { get; set; }  
    }
}
