using AutoMapper;
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
        private readonly IMapper _mapper;

        public MenuTablesController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = _menuTableService.TGetListAll();
            return Ok(_mapper.Map<List<ResultMenuTable>>(values));
        }

        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTable createMenuTable)
        {
            createMenuTable.Status = false;
            var value = _mapper.Map<MenuTable>(createMenuTable);
            _menuTableService.TAdd(value);
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
            updateMenuTable.Status = false;
            var value = _mapper.Map<MenuTable>(updateMenuTable);
            _menuTableService.TUpdate(value);
            return Ok("Menu Alanı Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.TGetByID(id);
            return Ok(_mapper.Map<GetMenuTableDto>(value));
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }
    }
}
