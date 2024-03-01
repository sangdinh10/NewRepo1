using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repository
{
    public interface IDiscountCouponRepository
    {
        List<DiscountCoupon> GetDiscountCoupons();
        DiscountCoupon GetDiscountCouponById(int id);
        void SaveDiscountCoupon(DiscountCoupon discountCoupon);
        void UpdateDiscountCoupon(DiscountCoupon discountCoupon);
        void DeleteDiscountCoupon(DiscountCoupon discountCoupon);
    }
}
