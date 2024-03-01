using ProjectLibrary.DataAccess;
using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repository
{
    public class DiscountCouponRepository : IDiscountCouponRepository
    {
        public List<DiscountCoupon> GetDiscountCoupons() => DiscountCouponDao.Instance.GetDiscountCoupons();
        public DiscountCoupon GetDiscountCouponById(int id) => DiscountCouponDao.Instance.GetDiscountCouponById(id);
        public void SaveDiscountCoupon(DiscountCoupon discountCoupon) => DiscountCouponDao.Instance.SaveDiscountCoupon(discountCoupon);
        public void UpdateDiscountCoupon(DiscountCoupon discountCoupon) => DiscountCouponDao.Instance.UpdateDiscountCoupon(discountCoupon);
        public void DeleteDiscountCoupon(DiscountCoupon discountCoupon) => DiscountCouponDao.Instance.DeleteDiscountCoupon(discountCoupon);
    }
}
