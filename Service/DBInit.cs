using CatalogueApp.Model;
using System;

namespace CatalogueApp.Service
{
    public static class DBInit{
        public static void initData(CatalogueRepository catalogueRepository){
            Console.WriteLine("Data Initialization...");
            catalogueRepository.Categories.Add(new Category{Name="Ordinateurs"});
            catalogueRepository.Categories.Add(new Category{Name="Imprimantes"});
            catalogueRepository.Products.Add(new Product{Name="Ordinateur HP 540", price=650.8, CategoryID=1});
            catalogueRepository.Products.Add(new Product{Name="Ordinateur Lenovo 510", price=120.9, CategoryID=1});
            catalogueRepository.Products.Add(new Product{Name="Mac Book Pro", price=1000.7, CategoryID=1});
            catalogueRepository.Products.Add(new Product{Name="Imprimante Epson 7654", price=170.5, CategoryID=2});
            catalogueRepository.SaveChanges();
        }
    } 
}