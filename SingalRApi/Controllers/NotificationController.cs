using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SingalR.BusinessLayer.Abstract;
using SingalR.DtoLayer.NotificationDto;
using SingalR.EntityLayer.Entities;

namespace SingalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(_notificationService.TGetListAll());
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }

        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationByFalse());
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            Notification notification = new Notification
            {
                Type = createNotificationDto.Type,
                Description = createNotificationDto.Description,
                Status = false,
                Icon = createNotificationDto.Icon,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            };
            _notificationService.TAdd(notification);
            return Ok("Ekleme İşlemi Başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            _notificationService.TDelete(value);
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            Notification notification = new Notification
            {
                NotificationID = updateNotificationDto.NotificationID,
                Type = updateNotificationDto.Type,
                Description = updateNotificationDto.Description,
                Status = updateNotificationDto.Status,
                Icon = updateNotificationDto.Icon,
                Date = updateNotificationDto.Date
            };
            _notificationService.TUpdate(notification);
            return Ok("Güncelleme İşlemi Başarılı");
        }

        [HttpGet("NotificationStatusChangeToFalse/id")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            _notificationService.TNotificationStatusChangeToFalse(id);
            return Ok("Güncelleme Başarılı");
        }

        [HttpGet("NotificationStatusChangeToTrue/id")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationStatusChangeToTrue(id);
            return Ok("Güncelleme Başarılı");
        }
    }
}
