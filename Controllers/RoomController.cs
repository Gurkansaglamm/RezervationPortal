using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RezervationPortal.Abstract;
using RezervationPortal.Data.DTO.RoomDtos; // DTO'larınızın namespace'i
using RezervationPortal.Entities;
using System.Threading.Tasks;

namespace RezervationPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController(IRoomRepository _roomRepository, IGenericRepository<Room> _genericRepository, IMapper _mapper) : ControllerBase
    {
        // Tüm odaları getirir.
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _genericRepository.GetAllAsync();
            return Ok(rooms);
        }

        // Belirtilen id'ye sahip odayı getirir.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var room = await _genericRepository.GetByIdAsync(id);
            if (room == null)
                return NotFound();
            return Ok(room);
        }

        // Yeni oda ekler.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoomDto createRoomDto)
        {
            var newRoom = _mapper.Map<Room>(createRoomDto);
            await _genericRepository.AddAsync(newRoom);
            return CreatedAtAction(nameof(GetById), new { id = newRoom.Id }, newRoom);
        }

        // Mevcut odayı günceller.
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRoomDto updateRoomDto)
        {
            var updatedRoom = _mapper.Map<Room>(updateRoomDto);
            await _genericRepository.UpdateAsync(updatedRoom);
            return NoContent();
        }
    }
}
