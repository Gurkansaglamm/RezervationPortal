using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RezervationPortal.Abstract;
using RezervationPortal.Data.DTO.ReservationDtos;
using RezervationPortal.Entities;

namespace RezervationPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController(IReservationRepository _reservationRepository,
                                       IGenericRepository<Reservation> _genericRepository,
                                       IMapper _mapper) : ControllerBase
    {
        // Tüm rezervasyonları getirir (CRUD işlemi için generic repository kullanılıyor)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reservations = await _genericRepository.GetAllAsync();
            return Ok(reservations);
        }

        // Belirtilen id'ye sahip rezervasyonu getirir.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reservation = await _genericRepository.GetByIdAsync(id);
            if (reservation == null)
                return NotFound();
            return Ok(reservation);
        }

        // Yeni rezervasyon ekler.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReservationDto createReservationDto)
        {
            // DTO'dan Reservation entity'sine dönüşüm yapılıyor.
            var newReservation = _mapper.Map<Reservation>(createReservationDto);
            await _genericRepository.AddAsync(newReservation);
            return CreatedAtAction(nameof(GetById), new { id = newReservation.Id }, newReservation);
        }

        // Mevcut rezervasyonu günceller.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateReservationDto updateReservationDto)
        {
            if (id != updateReservationDto.Id)
                return BadRequest();
            // DTO'dan Reservation entity'sine dönüşüm yapılıyor.
            var updatedReservation = _mapper.Map<Reservation>(updateReservationDto);
            await _genericRepository.UpdateAsync(updatedReservation);
            return NoContent();
        }

        // Rezervasyonu siler.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _genericRepository.DeleteAsync(id);
            return NoContent();
        }

        // Ekstra özel metot: Statüye göre rezervasyonları getirir.
        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var reservations = await _reservationRepository.GetReservationsByStatusAsync(status);
            return Ok(reservations);
        }

        // Ekstra özel metot: Belirli bir oda (roomId) için rezervasyonları getirir.
        [HttpGet("room/{roomId}")]
        public async Task<IActionResult> GetByRoomId(int roomId)
        {
            var reservations = await _reservationRepository.GetReservationsByRoomIdAsync(roomId);
            return Ok(reservations);
        }

        // Ekstra özel metot: Belirli bir misafirin (guestId) rezervasyonlarını getirir.
        [HttpGet("guest/{guestId}")]
        public async Task<IActionResult> GetByGuestId(int guestId)
        {
            var reservations = await _reservationRepository.GetReservationsByGuestIdAsync(guestId);
            return Ok(reservations);
        }
    }
}
