using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SingalR.BusinessLayer.Abstract;
using SingalR.DtoLayer.MessageDto;
using SingalR.EntityLayer.Entities;

namespace SingalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message message = new Message()
            {
                Mail = createMessageDto.Mail,
                MessageContent = createMessageDto.MessageContent,
                NameSurname = createMessageDto.NameSurname,
                Phone = createMessageDto.Phone,
                SendDate = createMessageDto.SendDate,
                Status = false,
                Subject = createMessageDto.Subject
            };

            _messageService.TAdd(message);
            return Ok("Mesajlar Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            _messageService.TDelete(value);
            return Ok("Mesajlar Silindi");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            Message message = new Message()
            {
                MessageID = updateMessageDto.MessageID,
                Mail = updateMessageDto.Mail,
                MessageContent = updateMessageDto.MessageContent,
                NameSurname = updateMessageDto.NameSurname,
                Phone = updateMessageDto.Phone,
                SendDate = updateMessageDto.SendDate,
                Status = false,
                Subject = updateMessageDto.Subject
            };

            _messageService.TUpdate(message);
            return Ok("Mesajlar Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            return Ok(value);
        }
    }
}
