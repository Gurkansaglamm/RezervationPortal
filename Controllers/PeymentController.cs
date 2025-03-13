using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RezervationPortal.Abstract;
using RezervationPortal.Data.DTO.PaymentDtos;
using RezervationPortal.Entities;
using RezervationPortal.Repository;

namespace RezervationPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeymentController (IPaymentRepository _paymentRepository,IGenericRepository<Payment> _genericRepository, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payments = await _genericRepository.GetAllAsync();
            return Ok(payments);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reservation = await _genericRepository.GetByIdAsync(id);
            if (reservation == null)
                return NotFound();
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaymentDto createPaymentDto)
        {
            var newPayment = _mapper.Map<Payment>(createPaymentDto);
            await _genericRepository.AddAsync(newPayment);
            return CreatedAtAction(nameof(GetById), new { id = newPayment.Id }, newPayment);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePaymentDto updatePaymentDto)
        {
           
            var updatedPayment = _mapper.Map<Payment>(updatePaymentDto);
            await _genericRepository.UpdateAsync(updatedPayment);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePaymentDto updatePaymentDto)
        {
            if (id != updatePaymentDto.Id)
                return BadRequest();
            var updatedPayment = _mapper.Map<Payment>(updatePaymentDto);
            await _genericRepository.UpdateAsync(updatedPayment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _genericRepository.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("GetPaymentsByPaymentDateAsync/{datetime}")]
        public async Task<IActionResult> GetPaymentsByPaymentDateAsync(DateTime datetime)
        {
            var payments = await _paymentRepository.GetPaymentsByPaymentDateAsync(datetime);
            return Ok(payments);
        }

        [HttpGet("GetPaymentsByReservationIdAsync/{id}")]
        public async Task<IActionResult> GetPaymentsByReservationIdAsync(int id)
        {
            var payments = await _paymentRepository.GetPaymentsByReservationIdAsync(id);
            return Ok(payments);
        }

        [HttpGet("GetPaymentsByStatusAsync/{status}")]
        public async Task<IActionResult> GetPaymentsByStatusAsync(string status)
        {
            var payments = await _paymentRepository.GetPaymentsByStatusAsync(status);
            return Ok(payments);
        }
    }
}
