using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.ObjectBussiness;
using ProjectLibrary.Repository;


  

    namespace ProjectWebAPI.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
  
    public class ShippingController : ControllerBase
    {
        private IShippingRepository _response = new ShippingRepository();
        // GET: api/<ShippingController>
        [HttpGet]
        public ActionResult<IEnumerable<Shipping>> Getshippings() => _response.GetShippings();


        // GET api/<ShippingController>/5
        [HttpGet("{id}")]
        public ActionResult<Shipping> GetShippingById(int id)
        {
            var shipping = _response.GetShippingById(id);
            if (shipping == null)
            {
                return NotFound();
            }
            return shipping;
        }

        // POST api/<ShippingController>
        [HttpPost]
        public IActionResult Postshipping(Shipping spDTO)
        {
            if (ModelState.IsValid)
            {
                var newshipping = new Shipping
                {
                    ShippingId = spDTO.ShippingId,
                    OrderId = spDTO.OrderId,
                    ShipDate = spDTO.ShipDate,
                    ShippingStatus = spDTO.ShippingStatus,
                    TrackingNumber = spDTO.TrackingNumber,
                };

                _response.SaveShipping(newshipping);

                return Ok("Notification created successfully");
            }

            return BadRequest("Invalid notification data");
        }

        // PUT api/<ShippingController>/5
        [HttpPut("{id}")]
        public IActionResult Putshipping(int id, Shipping spDTO)
        {
            var existingshipping = _response.GetShippingById(id);

            if (existingshipping == null)
            {
                return NotFound();
            }

            // Cập nhật các thuộc tính của existingNotification từ nDTO
            existingshipping.ShippingId = spDTO.ShippingId;
            existingshipping.OrderId = spDTO.OrderId;
            existingshipping.ShipDate = spDTO.ShipDate;
            existingshipping.ShippingStatus = spDTO.ShippingStatus;
            existingshipping.TrackingNumber = spDTO.TrackingNumber;

            _response.UpdateShipping(existingshipping);

            return Ok("Notification updated successfully");
        }

        // DELETE api/<ShippingController>/5
        [HttpDelete("{id}")]
        public IActionResult Deleteshipping(int id)
        {
            var temp = _response.GetShippingById(id);
            if (temp == null)
            {
                return NotFound();
            }
            _response.DeleteShipping(temp);
            return Ok("Notification dalete successfully");
        }

    }

}

