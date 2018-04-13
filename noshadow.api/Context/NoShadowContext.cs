using System.Linq;
using Microsoft.EntityFrameworkCore;
using noshadow.api.Model.Entity;

namespace noshadow.api.Context
{
    public class NoShadowContext: DbContext
    {
        public NoShadowContext(DbContextOptions<NoShadowContext> options)
            : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        
        public DbSet<DeviceEntity> Devices { get; set; }
        public DbSet<LogEntity> Logs { get; set; }
        
    }
}