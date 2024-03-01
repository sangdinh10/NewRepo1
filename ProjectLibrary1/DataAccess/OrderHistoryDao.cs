using Microsoft.EntityFrameworkCore;
using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.DataAccess
{
    public class OrderHistoryDao
    {
        private static OrderHistoryDao instance = null;
        private static readonly object instanceLock = new object();

        public static OrderHistoryDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderHistoryDao();
                    }
                    return instance;
                }
            }
        }

        public List<OrderHistory> GetOrderHistories()
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    return context.OrderHistories.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving order histories list: " + ex.Message);
            }
        }

        public OrderHistory GetOrderHistoryById(int id)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var orderHistory = context.OrderHistories.FirstOrDefault(x => x.OrderHistoryId == id);
                    if (orderHistory == null)
                    {
                        throw new Exception("Order history doesn't exist");
                    }
                    return orderHistory;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SaveOrderHistory(OrderHistory orderHistory)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var existingOrderHistory = context.OrderHistories
                        .FirstOrDefault(x => x.OrderHistoryId == orderHistory.OrderHistoryId);

                    if (existingOrderHistory != null)
                    {
                        throw new Exception("Order history already exists");
                    }

                    context.OrderHistories.Add(orderHistory);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateOrderHistory(OrderHistory orderHistory)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var existingOrderHistory = context.OrderHistories
                        .FirstOrDefault(x => x.OrderHistoryId == orderHistory.OrderHistoryId);

                    if (existingOrderHistory != null)
                    {
                        context.Entry(existingOrderHistory).CurrentValues.SetValues(orderHistory);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Order history not found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteOrderHistory(OrderHistory orderHistory)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var orderHistoryToDelete = context.OrderHistories
                        .FirstOrDefault(x => x.OrderHistoryId == orderHistory.OrderHistoryId);

                    if (orderHistoryToDelete == null)
                    {
                        throw new Exception("Order history is null");
                    }

                    context.OrderHistories.Remove(orderHistoryToDelete);
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
