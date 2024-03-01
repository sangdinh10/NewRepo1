﻿using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
        Order GetOrderById(int id);
        void SaveOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
