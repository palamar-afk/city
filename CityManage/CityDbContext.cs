using CityManage.DAL;
using Microsoft.EntityFrameworkCore;

namespace CityManage
{
    public class CityDbContext : DbContext
    {
        public CityDbContext(DbContextOptions<CityDbContext> options) : base(options)
        { }
        
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Factory> Factories { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<PersonFactory> PersonsFactories { get; set; }
        public virtual DbSet<PersonHouse> PersonHouses { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
    }
}