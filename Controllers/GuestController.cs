using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RezervationPortal.Abstract;
using RezervationPortal.Data.DTO.GuestDtos;
using RezervationPortal.Entities;

namespace RezervationPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController(IGenericRepository<Guest> _genericRepository, IMapper _mapper) : ControllerBase
    {
        // Tüm misafirleri getirir.
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var guests = await _genericRepository.GetAllAsync();
            // İsteğe bağlı: Eğer dışa sadeleştirilmiş veri sunmak istiyorsanız, 
            // var guestDtos = _mapper.Map<IEnumerable<GuestDto>>(guests);
            // return Ok(guestDtos);
            return Ok(guests);
        }

        // Belirtilen id'ye göre misafiri getirir.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var guest = await _genericRepository.GetByIdAsync(id);
            if (guest == null)
                return NotFound();
            // İsteğe bağlı: var guestDto = _mapper.Map<GuestDto>(guest);
            // return Ok(guestDto);
            return Ok(guest);
        }

        // Yeni misafir ekler.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGuestDto createGuestDto)
        {
            // DTO'dan entity'ye dönüşüm yapılıyor.
            var newGuest = _mapper.Map<Guest>(createGuestDto);
            await _genericRepository.AddAsync(newGuest);
            // Geri dönüşte isteğe bağlı olarak entity'yi DTO'ya map edebilirsiniz.
            return CreatedAtAction(nameof(GetById), new { id = newGuest.Id }, newGuest);
        }

        // Mevcut misafiri günceller.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGuestDto updateGuestDto)
        {
            if (id != updateGuestDto.Id)
                return BadRequest();
            // DTO'dan entity'ye dönüşüm yapılıyor.
            var guestToUpdate = _mapper.Map<Guest>(updateGuestDto);
            await _genericRepository.UpdateAsync(guestToUpdate);
            return NoContent();
        }

        // Misafiri siler.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _genericRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
