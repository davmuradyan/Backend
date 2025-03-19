using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.DAO {
    public class MainDBContext : DbContext {
        public MainDBContext(DbContextOptions options) : base(options) { }

        public DbSet<StopEntity> Stops { get; set; }
    }
}
