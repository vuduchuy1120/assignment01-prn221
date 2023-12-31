﻿using _17_VuDucHuy_BussinessObject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product product) => ProductDAO.Instance.AddProduct(product);

        public void DeleteProduct(Product product) => ProductDAO.Instance.RemoveProduct(product);

        public Product GetProductByID(int productID) => ProductDAO.Instance.GetProductByID(productID);
        

        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProducts();

        public IEnumerable SearchProduct(string id, string name, string productPrice, string unitsInStock) => ProductDAO.Instance.SearchProduct(id, name, productPrice, unitsInStock);


        public void UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);
 
    }
}
