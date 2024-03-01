using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.DataAccess
{
    public class OrderDao
    {
        private static OrderDao instance = null;
        private static readonly object instanceLock = new object();

        public static OrderDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDao();
                    }
                    return instance;
                }
            }
        }

        public List<Order> GetOrders()
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    return context.Orders.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving orders list: " + ex.Message);
            }
        }

        public Order GetOrderById(int id)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var order = context.Orders.FirstOrDefault(x => x.OrderId == id);
                    if (order == null)
                    {
                        throw new Exception("Order doesn't exist");
                    }
                    return order;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SaveOrder(Order order)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var existingOrder = context.Orders
                        .FirstOrDefault(x => x.OrderId == order.OrderId);

                    if (existingOrder != null)
                    {
                        throw new Exception("Order already exists");
                    }

                    context.Orders.Add(order);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var existingOrder = context.Orders
                        .FirstOrDefault(x => x.OrderId == order.OrderId);

                    if (existingOrder != null)
                    {
                        context.Entry(existingOrder).CurrentValues.SetValues(order);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Order not found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteOrder(Order order)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var orderToDelete = context.Orders
                        .FirstOrDefault(x => x.OrderId == order.OrderId);

                    if (orderToDelete == null)
                    {
                        throw new Exception("Order is null");
                    }

                    context.Orders.Remove(orderToDelete);
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
