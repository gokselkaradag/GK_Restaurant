﻿using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SingalR.BusinessLayer.Abstract;
using SingalR.DtoLayer.BookingDto;
using SingalR.EntityLayer.Entities;
using System.Diagnostics;

namespace SingalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookingDto> _validator;

        public BookingController(IBookingService bookingService, IMapper mapper, IValidator<CreateBookingDto> validator)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(_mapper.Map<List<ResultBookingDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var validatorResult = _validator.Validate(createBookingDto);
            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }

            var value = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(value);
            return Ok("Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            _bookingService.TDelete(value);
            return Ok("Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public IActionResult UppdateBooking(UpdateBookingDto updateBookingDto)
        {
            var value = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(value);
            return Ok("Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(_mapper.Map<GetBookingDto>(value));
        }

        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.TBookingStatusApproved(id);
            return Ok("Başarılı Bir Şekilde Onaylandı");
        }

        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            _bookingService.TBookingStatusCancelled(id);
            return Ok("Başarılı Bir Şekilde İptal Edildi");
        }
    }
}
