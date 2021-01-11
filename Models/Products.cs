using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogueApp.Model
{
    public class Product
    {
        public int ProductID {get; set;}
        public string Name {get; set;}
        public double price {get; set;}
        public int CategoryID {get; set;}
        [ForeignKey("CategoryID")]
        public virtual Category Category {get; set;}
    }
}