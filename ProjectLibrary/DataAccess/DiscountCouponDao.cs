using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.DataAccess
{
    public class DiscountCouponDao
    {
        private static DiscountCouponDao instance = null;
        private static readonly object instanceLock = new object();

        public static DiscountCouponDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new DiscountCouponDao();
                    }
                    return instance;
                }
            }
        }

        public List<DiscountCoupon> GetDiscountCoupons()
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    return context.DiscountCoupons.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving discount coupons list: " + ex.Message);
            }
        }

        public DiscountCoupon GetDiscountCouponById(int id)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var discountCoupon = context.DiscountCoupons.FirstOrDefault(x => x.CouponId == id);
                    if (discountCoupon == null)
                    {
                        throw new Exception("Discount coupon doesn't exist");
                    }
                    return discountCoupon;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SaveDiscountCoupon(DiscountCoupon discountCoupon)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var existingDiscountCoupon = context.DiscountCoupons
                        .FirstOrDefault(x => x.CouponId == discountCoupon.CouponId);

                    if (existingDiscountCoupon != null)
                    {
                        throw new Exception("Discount coupon already exists");
                    }

                    context.DiscountCoupons.Add(discountCoupon);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateDiscountCoupon(DiscountCoupon discountCoupon)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var existingDiscountCoupon = context.DiscountCoupons
                        .FirstOrDefault(x => x.CouponId == discountCoupon.CouponId);

                    if (existingDiscountCoupon != null)
                    {
                        context.Entry(existingDiscountCoupon).CurrentValues.SetValues(discountCoupon);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Discount coupon not found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteDiscountCoupon(DiscountCoupon discountCoupon)
        {
            try
            {
                using (var context = new DoAnWedSachContext())
                {
                    var discountCouponToDelete = context.DiscountCoupons
                        .FirstOrDefault(x => x.CouponId == discountCoupon.CouponId);

                    if (discountCouponToDelete == null)
                    {
                        throw new Exception("Discount coupon is null");
                    }

                    context.DiscountCoupons.Remove(discountCouponToDelete);
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
