using _17_VuDucHuy_BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(Order order) => OrderDAO.Instance.DeleteOrder(order);


        public Order GetOrderByID(int orderID) => OrderDAO.Instance.GetOrderByID(orderID);


        public IEnumerable<Order> GetOrders() => OrderDAO.Instance.GetAllOrders();


        public void InsertOrder(Order order) => OrderDAO.Instance.AddOrder(order);
 

        public void UpdateOrder(Order order) => OrderDAO.Instance.UpdateOrder(order);

    }
}
