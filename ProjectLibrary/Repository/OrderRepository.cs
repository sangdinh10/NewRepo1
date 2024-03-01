using ProjectLibrary.DataAccess;
using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public List<Order> GetOrders() => OrderDao.Instance.GetOrders();
        public Order GetOrderById(int id) => OrderDao.Instance.GetOrderById(id);
        public void SaveOrder(Order order) => OrderDao.Instance.SaveOrder(order);
        public void UpdateOrder(Order order) => OrderDao.Instance.UpdateOrder(order);
        public void DeleteOrder(Order order) => OrderDao.Instance.DeleteOrder(order);
    }
}
