using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repository
{
    public interface IOrderHistoryRepository
    {
        List<OrderHistory> GetOrderHistories();
        OrderHistory GetOrderHistoryById(int id);
        void SaveOrderHistory(OrderHistory orderHistory);
        void UpdateOrderHistory(OrderHistory orderHistory);
        void DeleteOrderHistory(OrderHistory orderHistory);
    }

}
