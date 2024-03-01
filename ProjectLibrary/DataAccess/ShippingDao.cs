using Microsoft.EntityFrameworkCore;
using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.DataAccess
{
    public class ShippingDAO
    {
        private static ShippingDAO instance = null;
        private static readonly object instanceLock = new object();

        public static ShippingDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ShippingDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Shipping> GetShippings()
        {
            var list = new List<Shipping>();
            try
            {
                using (var context = new DoAnWedSachContext()) // Thay YourDbContext bằng đối tượng DbContext của bạn
                {
                    list = context.Shippings.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving shippings list: " + ex.Message);
            }
            return list;
        }

        public List<Shipping> GetShippingListById(int id)
        {
            var list = new List<Shipping>();
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    list = context.Shippings.ToList();
                    list = list.Where(x => x.ShippingId.Equals(id)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving shippings list: " + ex.Message);
            }
            return list;
        }

        public Shipping GetShippingById(int id)
        {
            Shipping shipping = new Shipping();
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    shipping = context.Shippings.FirstOrDefault(x => x.ShippingId == id);
                }
                if (shipping == null)
                {
                    throw new Exception("Shipping doesn't exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return shipping;
        }

        public void SaveShipping(Shipping shipping)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var existingShipping = context.Shippings.FirstOrDefault(x => x.ShippingId == shipping.ShippingId);
                    if (existingShipping != null)
                    {
                        throw new Exception("Shipping already exists");
                    }

                    context.Shippings.Add(shipping);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateShipping(Shipping shipping)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var existingShipping = context.Shippings.FirstOrDefault(x => x.ShippingId == shipping.ShippingId);

                    if (existingShipping != null)
                    {
                        context.Entry(existingShipping).CurrentValues.SetValues(shipping);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Shipping not found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteShipping(Shipping shipping)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var shippingToDelete = context.Shippings.FirstOrDefault(x => x.ShippingId == shipping.ShippingId);
                    if (shippingToDelete == null)
                    {
                        throw new Exception("Shipping is null");
                    }
                    else
                    {
                        context.Shippings.Remove(shippingToDelete);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

