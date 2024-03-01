using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.DataAccess;
using ProjectLibrary.ObjectBussiness;
using ProjectLibrary.Repository;

namespace ProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository _response = new OrderRepository();
        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders() => _response.GetOrders();


        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var Order = _response.GetOrderById(id);
            if (Order == null)
            {
                return NotFound();
            }
            return Order;
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult PostOrderHistory(OrderDTO odDTO)
        {
            if (ModelState.IsValid)
            {
                var newOrder = new Order
                {
                    OrderId = odDTO.OrderId,
                    UserId = odDTO.UserId,
                    OrderDate = odDTO.OrderDate,
                    TotalAmount = odDTO.TotalAmount,
                    CouponId = odDTO.CouponId
                };

                _response.SaveOrder(newOrder);

                return Ok("Order created successfully");
            }

            return BadRequest("Invalid Order data");
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public IActionResult PutOrderHistory(int id, OrderDTO odDTO)
        {
            var existingOrder = _response.GetOrderById(id);

            if (existingOrder == null)
            {
                return NotFound();
            }

            // Cập nhật các thuộc tính của  existingOrder từ nDTO
            existingOrder.OrderId = odDTO.OrderId;
            existingOrder.UserId = odDTO.UserId;
            existingOrder.OrderDate = odDTO.OrderDate;
            existingOrder.TotalAmount = odDTO.TotalAmount;
            existingOrder.CouponId = odDTO.CouponId;

            _response.UpdateOrder(existingOrder);

            return Ok("Order updated successfully");
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var temp = _response.GetOrderById(id);
            if (temp == null)
            {
                return NotFound();
            }
            _response.DeleteOrder(temp);
            return Ok("OrderHistory dalete successfully");
        }

    }

}

