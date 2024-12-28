using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SingalR.BusinessLayer.Abstract;

namespace SingalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCasesController : ControllerBase
    {
        private readonly IMoneyCaseService _moneyCaseService;

        public MoneyCasesController(IMoneyCaseService moneyCaseService)
        {
            _moneyCaseService = moneyCaseService;
        }

        [HttpGet]
        public IActionResult TotalMoneyCaseAmount()
        {
            return Ok(_moneyCaseService.TTotalMoneyCaseAmount());
        }
    }
}
