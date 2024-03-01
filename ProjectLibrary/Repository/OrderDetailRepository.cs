using ProjectLibrary.DataAccess;
using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public List<OrderDetail> GetOrderDetails() => OrderDetailDao.Instance.GetOrderDetails();
        public OrderDetail GetOrderDetailById(int id) => OrderDetailDao.Instance.GetOrderDetailById(id);
        public void SaveOrderDetail(OrderDetail orderDetail) => OrderDetailDao.Instance.SaveOrderDetail(orderDetail);
        public void UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailDao.Instance.UpdateOrderDetail(orderDetail);
        public void DeleteOrderDetail(OrderDetail orderDetail) => OrderDetailDao.Instance.DeleteOrderDetail(orderDetail);
    }

}
