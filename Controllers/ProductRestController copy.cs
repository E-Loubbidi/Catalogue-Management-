using CatalogueApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CatalogueApp.Controllers
{
    [Route("/api/products")]
    public class ProductRestController:Controller
    {
        public CatalogueRepository catalogueRepository {get; set;}

        public ProductRestController(CatalogueRepository catalogueRepository){
            this.catalogueRepository  = catalogueRepository;
        }
        [HttpGet]
        public IEnumerable<Product> findAll(){
            return catalogueRepository.Products.Include(p => p.Category);
        }

         [HttpGet("paginate")]
        public IEnumerable<Product> page(int page = 0, int size = 1){
            int skipValue = (page - 1) * size;
            return catalogueRepository.Products.Include(p => p.Category).Skip(skipValue).Take(size);
        }

        [HttpPost]
        public Product save([FromBody]Product product){
            catalogueRepository.Products.Add(product);
            catalogueRepository.SaveChanges();
            return product;
        }

        [HttpGet("{Id}")]
        public Product getProd(long Id){
            return catalogueRepository.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductID==Id);
        }

          [HttpGet("search")]
        public IEnumerable<Product> search(string kw){
            return catalogueRepository.Products.Include(p => p.Category).Where(p => p.Name.Contains(kw));
        }

        [HttpPut("{Id}")]
        public Product update([FromBody]Product product, int Id){
            product.ProductID = Id;
            catalogueRepository.Products.Update(product);
            catalogueRepository.SaveChanges();
            return product;
        }
        [HttpDelete("{Id}")]
        public void Delete(int Id){
            Product product = catalogueRepository.Products.FirstOrDefault(p => p.ProductID==Id);
            catalogueRepository.Products.Remove(product);
            catalogueRepository.SaveChanges();
        }
    }
}