using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SingalR.BusinessLayer.Abstract;
using SingalR.DtoLayer.SliderDto;
using SingalR.EntityLayer.Entities;

namespace SingalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            _sliderService.TAdd(new Slider()
            {
                DescriptionOne = createSliderDto.DescriptionOne,
                DescriptionTwo = createSliderDto.DescriptionTwo,
                DescriptionThree = createSliderDto.DescriptionThree,
                TitleOne = createSliderDto.TitleOne,
                TitleTwo = createSliderDto.TitleTwo,
                TitleThree = createSliderDto.TitleThree,
            });

            return Ok("Özellikler Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetByID(id);
            _sliderService.TDelete(value);
            return Ok("Özellikler Silindi");
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            _sliderService.TUpdate(new Slider()
            {
                SliderID = updateSliderDto.SliderID,
                DescriptionOne = updateSliderDto.DescriptionOne,
                DescriptionTwo = updateSliderDto.DescriptionTwo,
                DescriptionThree = updateSliderDto.DescriptionThree,
                TitleOne = updateSliderDto.TitleOne,
                TitleTwo = updateSliderDto.TitleTwo,
                TitleThree = updateSliderDto.TitleThree,
            });

            return Ok("Özellikler Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var values = _sliderService.TGetByID(id);
            return Ok(values);
        }
    }
}
