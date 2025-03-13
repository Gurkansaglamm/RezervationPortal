using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RezervationPortal.Abstract;
using RezervationPortal.Entities;
using Microsoft.EntityFrameworkCore;
using RezervationPortal.Data;

namespace RezervationPortal.Repository
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(RezervationPortalContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByPaymentDateAsync(DateTime paymentDate)
        {
            return await _dbSet.Where(p => p.PaymentDate == paymentDate).ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByReservationIdAsync(int reservationId)
        {
            return await _dbSet.Where(p => p.ReservationId == reservationId).ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByStatusAsync(string status)
        {
            return await _dbSet.Where(p => p.Status.ToLower() == status.ToLower()).ToListAsync();
        }
    }
}
