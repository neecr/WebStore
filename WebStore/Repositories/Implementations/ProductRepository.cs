﻿using WebStore.Data;
using WebStore.Exceptions;
using WebStore.Models;
using WebStore.Repositories.Interfaces;

namespace WebStore.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.ProductId).ToList();
        }

        public Product GetProductById(int productId)
        {
            var product = (from p in _context.Products
                join c in _context.Categories on p.CategoryId equals c.CategoryId
                where p.ProductId == productId
                select new Product
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price,
                    Category = c
                }).FirstOrDefault();

            if (product == null) throw new NotFoundException("The product with such ID is not found.");
            return product;
        }

        public void CreateProduct(int categoryId, Product product)
        {
            if (_context.Categories.Find(categoryId) == null)
                throw new NotFoundException("The category with such ID is not found.");

            product.CategoryId = categoryId;
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product UpdateProduct(int productId, Product product)
        {
            var existingProduct = _context.Products.Find(productId);
            if (existingProduct == null) throw new NotFoundException("The product with such ID is not found.");
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.CategoryId = product.CategoryId;

            _context.SaveChanges();

            return existingProduct;
        }

        public bool IsProductExists(int productId)
        {
            return _context.Products.Any(p => p.ProductId == productId);
        }
    }
}
