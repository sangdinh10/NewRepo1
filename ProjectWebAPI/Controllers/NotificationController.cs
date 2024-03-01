using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.ObjectBussiness;
using ProjectLibrary.Repository;

namespace ProjectWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private INotificationRepository _response = new NotificationRepository();
        // GET: api/<NotificationController>
        [HttpGet]
        public ActionResult<IEnumerable<Notification>> GetNotifications() => _response.GetNotifications();


        // GET api/<NotificationController>/5
        [HttpGet("{id}")]
        public ActionResult<Notification> GetNotificationById(int id)
        {
            var Notification = _response.GetNotificationById(id);
            if (Notification == null)
            {
                return NotFound();
            }
            return Notification;
        }

        // POST api/<NotificationController>
        [HttpPost]
        public IActionResult PostNotification(Notification NotDTO)
        {
            if (ModelState.IsValid)
            {
                var newNotification = new Notification
                {
                    NotificationId = NotDTO.NotificationId,
                    Title = NotDTO.Title,
                    Description = NotDTO.Description,
                    SentDate = NotDTO.SentDate,
                  
                };

                _response.SaveNotification(newNotification);

                return Ok("Notification created successfully");
            }

            return BadRequest("Invalid Notification data");
        }

        // PUT api/<NotificationController>/5
        [HttpPut("{id}")]
        public IActionResult PutNotification(int id, Notification NotDTO)
        {
            var existingNotification = _response.GetNotificationById(id);

            if (existingNotification == null)
            {
                return NotFound();
            }

            // Cập nhật các thuộc tính của  existingOrder từ nDTO
            existingNotification.NotificationId = NotDTO.NotificationId;
            existingNotification.Title = NotDTO.Title;
            existingNotification.Description = NotDTO.Description;
            existingNotification.SentDate = NotDTO.SentDate;

            _response.UpdateNotification(existingNotification);

            return Ok("Notification updated successfully");
        }

        // DELETE api/<NotificationController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var temp = _response.GetNotificationById(id);
            if (temp == null)
            {
                return NotFound();
            }
            _response.DeleteNotification(temp);
            return Ok("Notification dalete successfully");
        }

    }

}
 
