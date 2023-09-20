using _17_VuDucHuy_BussinessObject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderByID(int orderID);
        void InsertOrder(Order order);
        void DeleteOrder(Order order);
        void UpdateOrder(Order order);
        IEnumerable SearchOrder(DateTime startDate, DateTime endDate);
        IEnumerable<Order> GetOrdersByMemberID(int memberID);
        IEnumerable SearchOrderByMemberID(DateTime startDate, DateTime endDate,int memberID);
    }
}
