﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _product;

        public InMemoryProductDal()
        {
            _product = new List<Product> {
            new Product{ProductId=1 ,CategoryId=1 ,ProductName="Bardak" , UnitPrice=15 , UnitsInStock=15},
            new Product{ProductId=2 ,CategoryId=1 ,ProductName="Kamera" , UnitPrice=500 , UnitsInStock=3},
            new Product{ProductId=3 ,CategoryId=2 ,ProductName="Telefon" , UnitPrice=1500 , UnitsInStock=2},
            new Product{ProductId=4 ,CategoryId=2 ,ProductName="Klavye" , UnitPrice=150 , UnitsInStock=65},
            new Product{ProductId=5 ,CategoryId=2 ,ProductName="Fare" , UnitPrice=85 , UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _product.Add(product);
        }

        public void Delete(Product product)
        {
            Product ProductToDelete = _product.SingleOrDefault(p => p.ProductId == product.ProductId); //LINQ
            _product.Remove(ProductToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
           return _product;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int category)
        {
            return _product.Where(p => p.CategoryId == category).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product ProductToUpdate = _product.SingleOrDefault(p => p.ProductId == product.ProductId); //LINQ
            ProductToUpdate.ProductName = product.ProductName;
            ProductToUpdate.CategoryId = product.CategoryId;
            ProductToUpdate.UnitPrice = product.UnitPrice;
            ProductToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
