using CatalogueApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CatalogueApp.Controllers
{
    [Route("/api/categories")]
    public class CategoryRestController:Controller
    {
        public CatalogueRepository catalogueRepository {get; set;}

        public CategoryRestController(CatalogueRepository catalogueRepository){
            this.catalogueRepository  = catalogueRepository;
        }
        [HttpGet]
        public IEnumerable<Category> ListCats(){
            return catalogueRepository.Categories;
        }
        [HttpPost]
        public Category save([FromBody]Category category){
            catalogueRepository.Categories.Add(category);
            catalogueRepository.SaveChanges();
            return category;
        }

        [HttpGet("{Id}")]
        public Category getCat(long Id){
            return catalogueRepository.Categories.FirstOrDefault(c => c.CategoryID==Id);
        }

         [HttpGet("{Id}/products")]
        public IEnumerable<Product> products(long Id){
            Category category = catalogueRepository.Categories.Include(c => c.Products).FirstOrDefault(c => c.CategoryID==Id);
            return category.Products;
        }

        [HttpPut("{Id}")]
        public Category update([FromBody]Category category, int Id){
            category.CategoryID = Id;
            catalogueRepository.Categories.Update(category);
            catalogueRepository.SaveChanges();
            return category;
        }
        [HttpDelete("{Id}")]
        public void Delete(int Id){
            Category category = catalogueRepository.Categories.FirstOrDefault(c => c.CategoryID==Id);
            catalogueRepository.Categories.Remove(category);
            catalogueRepository.SaveChanges();
        }
    }
}