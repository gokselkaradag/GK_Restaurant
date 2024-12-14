using AutoMapper;
using SingalR.DtoLayer.ContactDto;
using SingalR.EntityLayer.Entities;

namespace SingalRApi.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetContactDto>().ReverseMap();
        }
    }
}
