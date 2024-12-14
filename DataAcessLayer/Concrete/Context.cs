using DataEntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Concrete
{
   
    public class Context:IdentityDbContext<AppUser,AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-7GJPC0B\\SQLEXPRESS;Database=MvcCore;TrustServerCertificate=true;Integrated security=true");
         
        }
        public virtual DbSet<About>?Abouts { get; set; }
        public virtual DbSet<Category>?Categories { get; set; }
        public virtual DbSet<Blog>?Blogs { get; set; }
        public virtual DbSet<Comment>?Comments { get; set; }
        public virtual DbSet<Writer>?Writers { get; set; }
        public virtual DbSet<Contact>?Contacts{ get; set; }
        public virtual DbSet<Login>? Logins { get; set; }
        public virtual DbSet<BlogRayting>?BlogRaytings { get; set; }
        public virtual DbSet<Notification>? Notifications { get; set; }
        public virtual DbSet<Admin>?Admins { get; set; }
    }
}
