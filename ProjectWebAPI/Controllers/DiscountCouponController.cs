using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.ObjectBussiness;
using ProjectLibrary.Repository;

namespace ProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCouponController : ControllerBase
    {
        private IDiscountCouponRepository _response = new DiscountCouponRepository();
        // GET: api/<DiscountCouponController>
        [HttpGet]
        public ActionResult<IEnumerable<DiscountCoupon>> GetDiscountCoupons() => _response.GetDiscountCoupons();


        // GET api/<DiscountCouponController>/5
        [HttpGet("{id}")]
        public ActionResult<DiscountCoupon> GetDiscountCouponById(int id)
        {
            var DiscountCoupon = _response.GetDiscountCouponById(id);
            if (DiscountCoupon == null)
            {
                return NotFound();
            }
            return DiscountCoupon;
        }

        // POST api/<DiscountCouponController>
        [HttpPost]
        public IActionResult PostDiscountCoupon(DiscountCoupon DisDTO)
        {
            if (ModelState.IsValid)
            {
                var newDiscountCoupon = new DiscountCoupon
                {
                    CouponId = DisDTO.CouponId,
                    CouponCode = DisDTO.CouponCode,
                    DiscountPercentage = DisDTO.DiscountPercentage,
                    ExpiryDate = DisDTO.ExpiryDate,
                    
                };

                _response.SaveDiscountCoupon(newDiscountCoupon);

                return Ok("DiscountCoupon created successfully");
            }

            return BadRequest("Invalid DiscountCoupon data");
        }

        // PUT api/<DiscountCouponController>/5
        [HttpPut("{id}")]
        public IActionResult PutDiscountCoupon(int id, DiscountCouponDTO DisDTO)
        {
            var existingDiscountCoupon = _response.GetDiscountCouponById(id);

            if (existingDiscountCoupon == null)
            {
                return NotFound();
            }

            // Cập nhật các thuộc tính của  existingOrder từ nDTO
            existingDiscountCoupon.CouponId = DisDTO.CouponId;
            existingDiscountCoupon.CouponCode = DisDTO.CouponCode;
            existingDiscountCoupon.DiscountPercentage = DisDTO.DiscountPercentage;
            existingDiscountCoupon.ExpiryDate = DisDTO.ExpiryDate;

            _response.UpdateDiscountCoupon(existingDiscountCoupon);

            return Ok("DiscountCoupon updated successfully");
        }

        // DELETE api/<DiscountCouponController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscountCoupon(int id)
        {
            var temp = _response.GetDiscountCouponById(id);
            if (temp == null)
            {
                return NotFound();
            }
            _response.DeleteDiscountCoupon(temp);
            return Ok("DiscountCoupon dalete successfully");
        }

    }

}

