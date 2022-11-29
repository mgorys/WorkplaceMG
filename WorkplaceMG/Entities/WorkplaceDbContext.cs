using Microsoft.EntityFrameworkCore;

namespace WorkplaceMG.Entities
{
    
    public class WorkplaceDbContext : DbContext
    {
        public WorkplaceDbContext(DbContextOptions<WorkplaceDbContext> options) : base(options)
        {
        }
        //private string _connectionString =
        //   "Server=.;Database=WorkplaceDb;Trusted_Connection=True;";
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentForWorkplace> EquipmentForWorkplaces { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
        //}
    }
}
