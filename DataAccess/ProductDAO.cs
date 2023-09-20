using _17_VuDucHuy_BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        // using singleton pattern
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            List<Product> products;
            try
            {
                var myContext = new ShoppingContext();
                products = myContext.Products.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return products;
        }

        public void AddProduct(Product product)
        {
              try
            {
                var myContext = new ShoppingContext();
                myContext.Products.Add(product);
                myContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // getProductByID
        public Product GetProductByID(int productID)
        {
            Product product = null;
            try
            {
                var myContext = new ShoppingContext();
                product = myContext.Products.SingleOrDefault(p => p.ProductId == productID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return product;
        }
        public void RemoveProduct(Product product)
        {

            try
            {
                Product _product = GetProductByID(product.ProductId);
                if(_product != null)
                {
                    var myContext = new ShoppingContext();
                    myContext.Products.Remove(_product);
                    myContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Product not exists!");
                }

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                Product _product = GetProductByID(product.ProductId);
                if(_product != null)
                {
                    var myContext = new ShoppingContext();
                    myContext.Entry(product).State = EntityState.Modified;
                    myContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Product not exists!");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // SearchProduct(string id, string name, string productPrice, string unitsInStock)
        public IEnumerable SearchProduct(string id, string name, string productPrice, string unitsInStock)
        {
            List<Product> products = null;
            try
            {
                var myContext = new ShoppingContext();
                products = myContext.Products.Where(p => p.ProductId.ToString().Contains(id) && p.ProductName.Contains(name) && p.UnitPrice.ToString().Contains(productPrice) && p.UnitsInStock.ToString().Contains(unitsInStock)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return products;
        }

    }
}
