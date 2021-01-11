using CatalogueApp.Model;
using Microsoft.EntityFrameworkCore;


namespace CatalogueApp
{
    public class CatalogueRepository:DbContext
    {
        public DbSet<Category> Categories {get; set;} 
        public DbSet<Product> Products {get; set;} 
        public CatalogueRepository(DbContextOptions options):base(options){

        }
    }
}