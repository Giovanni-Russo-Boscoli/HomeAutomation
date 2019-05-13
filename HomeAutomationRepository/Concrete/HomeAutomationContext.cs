using HomeAutomationModel.Model;
using HomeAutomationModel.SonoffDualR2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HomeAutomationRepository.Concrete
{
    public class HomeAutomationContext: DbContext
    {
       
        public HomeAutomationContext(DbContextOptions<HomeAutomationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TYPEDEVICE
            modelBuilder.Entity<TypeDevice>().HasKey(p => p.Type_Id);
            modelBuilder.Entity<TypeDevice>().Property(t => t.Type_Id).HasColumnName("type_id").IsRequired();
            modelBuilder.Entity<TypeDevice>().Property(t => t.Description).HasColumnName("description").IsRequired();
            //modelBuilder.HasDefaultSchema("public");


            //ACTION
            modelBuilder.Entity<Action>().HasKey(a => a.Action_Id);
            modelBuilder.Entity<Action>().Property(a => a.Description).HasColumnName("description").IsRequired();
            modelBuilder.Entity<Action>().HasOne(a => a.TypeDevice).WithMany();


            //STATE
            modelBuilder.Entity<State>().HasKey(a => a.State_Id);
            modelBuilder.Entity<State>().Property(s => s.Description).HasColumnName("description").IsRequired();
            modelBuilder.Entity<State>().HasOne(a => a.TypeDevice).WithMany();

            //MODELDEVICE
            modelBuilder.Entity<ModelDevice>().HasKey(p => p.ModelDevice_Id);
            modelBuilder.Entity<ModelDevice>().Property(a =>a.ModelDevice_Id).HasColumnName("model_id").IsRequired();
            modelBuilder.Entity<ModelDevice>().Property(m => m.Description).HasColumnName("description").IsRequired();

            //DEVICE
            modelBuilder.Entity<Device>().HasKey(a => a.Device_Id);
            modelBuilder.Entity<Device>().Property(s => s.IP).HasColumnName("ip").IsRequired();
            modelBuilder.Entity<Device>().HasOne(a => a.ModelDevice).WithMany();
            modelBuilder.Entity<Device>().HasOne(a => a.Area).WithMany();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //use this to configure the contex
        //    optionsBuilder.UseNpgsql(_configuration.GetConnectionString("HomeAutomationConnection"));
        //}

        public DbSet<TypeDevice> TypeDevice { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Action> Action { get; set; }
        public DbSet<ModelDevice> ModelDevice { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Device> Device { get; set; }
    }
}
