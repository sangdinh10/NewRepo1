using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.ObjectBussiness;
using ProjectLibrary.Repository;
using System.Net;

namespace ProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private IOrderDetailRepository _response = new OrderDetailRepository();
        // GET: api/<OrderDetailController>
        [HttpGet]
        public ActionResult<IEnumerable<OrderDetail>> GetOrders() => _response.GetOrderDetails();


        // GET api/<OrderDetailController>/5
        [HttpGet("{id}")]
        public ActionResult<OrderDetail> GetOrderDetailById(int id)
        {
            var orderDetail = _response.GetOrderDetailById(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return orderDetail;
        }

        // POST api/<OrderDetailController>
        [HttpPost]
        public IActionResult PostOrderDetail(OrderDetail odDTO)
        {
            if (ModelState.IsValid)
            {
                var newOrderDetail = new OrderDetail
                {
                    OrderDetailId = odDTO.OrderDetailId,
                    OrderId = odDTO.OrderId,
                    BookId = odDTO.BookId,
                    Quantity = odDTO.Quantity,
                    Subtotal = odDTO.Subtotal
                };

                _response.SaveOrderDetail(newOrderDetail);

                return Ok("OrderDetail created successfully");
            }

            return BadRequest("Invalid OrderDetail data");
        }

        // PUT api/<OrderDetailController>/5
        [HttpPut("{id}")]
        public IActionResult PutOrderHistory(int id, OrderDetailDTO odDTO)
        {
            var existingOrderDetail = _response.GetOrderDetailById(id);

            if (existingOrderDetail == null)
            {
                return NotFound();
            }

            // Cập nhật các thuộc tính của   existingOrderDetail từ nDTO
            existingOrderDetail.OrderDetailId = odDTO.OrderDetailId;
            existingOrderDetail.OrderId = odDTO.OrderId;
            existingOrderDetail.BookId = odDTO.BookId;
            existingOrderDetail.Quantity = odDTO.Quantity;
            existingOrderDetail.Subtotal = odDTO.Subtotal;

            _response.UpdateOrderDetail(existingOrderDetail);

            return Ok("OrderDetail updated successfully");
        }

        // DELETE api/<OrderDetailController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrderDetail(int id)
        {
            var temp = _response.GetOrderDetailById(id);
            if (temp == null)
            {
                return NotFound();
            }
            _response.DeleteOrderDetail(temp);
            return Ok("OrderDetail dalete successfully");
        }

    }

}
  
