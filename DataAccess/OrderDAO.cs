using _17_VuDucHuy_BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        // using singleton pattern
        private static OrderDAO instance;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        //getOrder by ID
        public Order GetOrderByID(int orderID)
        {
            Order order = null;
            try
            {
                var myContext = new ShoppingContext();
                order = myContext.Orders.SingleOrDefault(o => o.OrderId == orderID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return order;
        }
        public IEnumerable<Order> GetAllOrders()
        {
              List<Order> orders;
            try
            {
                var myContext = new ShoppingContext();
                orders = myContext.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return orders;
        }

        public void AddOrder(Order order)
        {
            try
            {
                var myContext = new ShoppingContext();
                myContext.Orders.Add(order);
                myContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteOrder(Order order) {
            try
            {
                Order _order = GetOrderByID(order.OrderId);
                if(_order != null)
                {
                    var myContext = new ShoppingContext();
                    myContext.Orders.Remove(_order);
                    myContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Order not found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                Order _order = GetOrderByID(order.OrderId);
                if (_order != null)
                {
                    var myContext = new ShoppingContext();
                    myContext.Entry<Order>(order).State = EntityState.Modified;
                    myContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Order not found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal IEnumerable SearchOrder(DateTime startDate, DateTime endDate)
        {
            try
            {
                var myContext = new ShoppingContext();
                var orders = myContext.Orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).ToList();
                return orders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
