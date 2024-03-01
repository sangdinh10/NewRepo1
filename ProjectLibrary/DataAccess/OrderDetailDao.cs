using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.DataAccess
{
    public class OrderDetailDao
    {
        private static OrderDetailDao instance = null;
        private static readonly object instanceLock = new object();

        public static OrderDetailDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDao();
                    }
                    return instance;
                }
            }
        }

        public List<OrderDetail> GetOrderDetails()
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    return context.OrderDetails.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving order details list: " + ex.Message);
            }
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var orderDetail = context.OrderDetails.FirstOrDefault(x => x.OrderDetailId == id);
                    if (orderDetail == null)
                    {
                        throw new Exception("Order detail doesn't exist");
                    }
                    return orderDetail;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SaveOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var existingOrderDetail = context.OrderDetails
                        .FirstOrDefault(x => x.OrderDetailId == orderDetail.OrderDetailId);

                    if (existingOrderDetail != null)
                    {
                        throw new Exception("Order detail already exists");
                    }

                    context.OrderDetails.Add(orderDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var existingOrderDetail = context.OrderDetails
                        .FirstOrDefault(x => x.OrderDetailId == orderDetail.OrderDetailId);

                    if (existingOrderDetail != null)
                    {
                        context.Entry(existingOrderDetail).CurrentValues.SetValues(orderDetail);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Order detail not found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var orderDetailToDelete = context.OrderDetails
                        .FirstOrDefault(x => x.OrderDetailId == orderDetail.OrderDetailId);

                    if (orderDetailToDelete == null)
                    {
                        throw new Exception("Order detail is null");
                    }

                    context.OrderDetails.Remove(orderDetailToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
