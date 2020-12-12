using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Context {
    public class MyContext : DbContext {

        public DbSet<Offer> Offers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=DB/data.db");
    }
}