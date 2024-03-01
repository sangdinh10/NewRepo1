using ProjectLibrary.DataAccess;
using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repository
{
    public class OrderHistoryRepository : IOrderHistoryRepository
    {
        public List<OrderHistory> GetOrderHistories() => OrderHistoryDao.Instance.GetOrderHistories();

        public OrderHistory GetOrderHistoryById(int id) => OrderHistoryDao.Instance.GetOrderHistoryById(id);

        public void SaveOrderHistory(OrderHistory orderHistory) => OrderHistoryDao.Instance.SaveOrderHistory(orderHistory);

        public void UpdateOrderHistory(OrderHistory orderHistory) => OrderHistoryDao.Instance.UpdateOrderHistory(orderHistory);

        public void DeleteOrderHistory(OrderHistory orderHistory) => OrderHistoryDao.Instance.DeleteOrderHistory(orderHistory);
    }

}
