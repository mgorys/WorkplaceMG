using Microsoft.EntityFrameworkCore;

namespace WorkplaceMG.Entities
{

    public class WorkplaceDbContext : DbContext
    {
        public WorkplaceDbContext(DbContextOptions<WorkplaceDbContext> options) : base(options)
        {
        }

        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentForWorkplace> EquipmentForWorkplaces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                    new Employee { Id =1, FirstName = "Antony", LastName = "Hopkins" },
                    new Employee { Id =2, FirstName = "Tom", LastName = "Hanks" }
                );
            modelBuilder.Entity<Equipment>().HasData(
                    new Equipment { Id = 1, Type = "Headphones", StockCount = 3 },
                    new Equipment { Id = 2, Type = "Keyboard", StockCount = 3 },
                    new Equipment { Id = 3, Type = "Mouse", StockCount = 3 }
                );
            modelBuilder.Entity<Workplace>().HasData(
                    new Workplace { Id =1, Floor = 0, Room=1,Table=1 },
                    new Workplace { Id =2, Floor = 0, Room=1,Table=2 },
                    new Workplace { Id =3, Floor = 0, Room=2,Table=1 },
                    new Workplace { Id =4, Floor = 1, Room=1,Table=1 }
                );
            modelBuilder.Entity<EquipmentForWorkplace>().HasData(
                    new EquipmentForWorkplace { Id = 1, IdWorkplace = 1, IdEquipment =1 },
                    new EquipmentForWorkplace { Id = 2, IdWorkplace = 1, IdEquipment =2 },
                    new EquipmentForWorkplace { Id = 3, IdWorkplace = 2, IdEquipment =1 },
                    new EquipmentForWorkplace { Id = 4, IdWorkplace = 2, IdEquipment =2 },
                    new EquipmentForWorkplace { Id = 5, IdWorkplace = 3, IdEquipment =1 },
                    new EquipmentForWorkplace { Id = 6, IdWorkplace = 4, IdEquipment =2 }
                );
        }
    }
}
