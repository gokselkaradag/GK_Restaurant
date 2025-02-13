using AutoMapper;
using SingalR.DtoLayer.MenuTableDto;
using SingalR.EntityLayer.Entities;

namespace SingalRApi.Mapping
{
    public class MenuTableMapping : Profile
    {
        public MenuTableMapping()
        {
            CreateMap<MenuTable, ResultMenuTable>().ReverseMap();
            CreateMap<MenuTable, CreateMenuTable>().ReverseMap();
            CreateMap<MenuTable, UpdateMenuTable>().ReverseMap();
            CreateMap<MenuTable, GetMenuTableDto>().ReverseMap();
        }
    }
}
