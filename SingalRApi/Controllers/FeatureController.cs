using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SingalR.BusinessLayer.Abstract;
using SingalR.DtoLayer.FeatureDto;
using SingalR.EntityLayer.Entities;

namespace SingalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            _featureService.TAdd(new Feature()
            {
                DescriptionOne = createFeatureDto.DescriptionOne,
                DescriptionTwo = createFeatureDto.DescriptionTwo,
                DescriptionThree = createFeatureDto.DescriptionThree,
                TitleOne = createFeatureDto.TitleOne,
                TitleTwo = createFeatureDto.TitleTwo,
                TitleThree = createFeatureDto.TitleThree,
            });

            return Ok("Özellikler Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetByID(id);
            _featureService.TDelete(value);
            return Ok("Özellikler Silindi");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _featureService.TUpdate(new Feature()
            {
                FeatureID = updateFeatureDto.FeatureID,
                DescriptionOne = updateFeatureDto.DescriptionOne,
                DescriptionTwo = updateFeatureDto.DescriptionTwo,
                DescriptionThree = updateFeatureDto.DescriptionThree,
                TitleOne = updateFeatureDto.TitleOne,
                TitleTwo = updateFeatureDto.TitleTwo,
                TitleThree = updateFeatureDto.TitleThree,
            });

            return Ok("Özellikler Güncellendi");
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var values = _featureService.TGetByID(id);
            return Ok(values);
        }
    }
}
