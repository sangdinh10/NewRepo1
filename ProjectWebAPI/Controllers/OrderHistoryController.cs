using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.ObjectBussiness;
using ProjectLibrary.Repository;

namespace ProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHistoryController : ControllerBase
    {
        private IOrderHistoryRepository _response = new OrderHistoryRepository();
        // GET: api/<OrderHistoryController>
        [HttpGet]
        public ActionResult<IEnumerable<OrderHistory>> GetOrderHistories() => _response.GetOrderHistories();


        // GET api/<OrderHistoryController>/5
        [HttpGet("{id}")]
        public ActionResult<OrderHistory> GetOrderHistoryById(int id)
        {
            var OrderHistory = _response.GetOrderHistoryById(id);
            if (OrderHistory == null)
            {
                return NotFound();
            }
            return OrderHistory;
        }

        // POST api/<OrderHistoryController>
        [HttpPost]
        public IActionResult PostOrderHistory(OrderHistory odDTO)
        {
            if (ModelState.IsValid)
            {
                var newOrderHistory = new OrderHistory
                {
                    OrderHistoryId = odDTO.OrderHistoryId,
                    OrderId = odDTO.OrderId,
                    UserId = odDTO.UserId,
                    OrderStatus = odDTO.OrderStatus,
                    UpdateDate = odDTO.UpdateDate
                };

                _response.SaveOrderHistory(newOrderHistory);

                return Ok("OrderHistory created successfully");
            }

            return BadRequest("Invalid OrderHistory data");
        }

        // PUT api/<OrderHistoryController>/5
        [HttpPut("{id}")]
        public IActionResult PutOrderHistory(int id, OrderHistory odDTO)
        {
            var existingOrderHistory = _response.GetOrderHistoryById(id);

            if (existingOrderHistory == null)
            {
                return NotFound();
            }

            // Cập nhật các thuộc tính của  existingOrderHistory từ nDTO
            existingOrderHistory.OrderHistoryId = odDTO.OrderHistoryId;
            existingOrderHistory.OrderId = odDTO.OrderId;
            existingOrderHistory.UserId = odDTO.UserId;
            existingOrderHistory.OrderStatus = odDTO.OrderStatus;
            existingOrderHistory.UpdateDate = odDTO.UpdateDate;

            _response.UpdateOrderHistory(existingOrderHistory);

            return Ok("OrderHistory updated successfully");
        }

        // DELETE api/<OrderHistoryController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrderHistory(int id)
        {
            var temp = _response.GetOrderHistoryById(id);
            if (temp == null)
            {
                return NotFound();
            }
            _response.DeleteOrderHistory(temp);
            return Ok("OrderHistory dalete successfully");
        }

    }

}
    
