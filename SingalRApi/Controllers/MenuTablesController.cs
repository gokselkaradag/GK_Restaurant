using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SingalR.BusinessLayer.Abstract;
using SingalR.DtoLayer.MenuTableDto;
using SingalR.EntityLayer.Entities;

namespace SingalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTablesController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }

        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = _menuTableService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTable createMenuTable)
        {
            MenuTable menuTable = new MenuTable()
            {
                Name = createMenuTable.Name,
                Status = false
            };
            _menuTableService.TAdd(menuTable);
            return Ok("Menu Kısmı Başarılı Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.TGetByID(id);
            _menuTableService.TDelete(value);
            return Ok("Menu Alanı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTable updateMenuTable)
        {
            MenuTable menuTable = new MenuTable()
            {
                Name = updateMenuTable.Name,
                MenuTableID = updateMenuTable.MenuTableID,
                Status = false
            };

            _menuTableService.TUpdate(menuTable);
            return Ok("Menu Alanı Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.TGetByID(id);
            return Ok(value);
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }
    }
}
