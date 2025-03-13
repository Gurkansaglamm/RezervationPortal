using Microsoft.EntityFrameworkCore;
using RezervationPortal.Abstract;  // IGenericRepository'nuz burada tanımlı
using RezervationPortal.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RezervationPortal.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly RezervationPortalContext _context;
        protected readonly DbSet<T> _dbSet;

        // Tabloya kolay erişim için property
        public DbSet<T> Table { get => _context.Set<T>(); }

        // Constructor: DbContext nesnesi alınıp _context ve _dbSet initialize ediliyor.
        public GenericRepository(RezervationPortalContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Entity'yi asenkron olarak ekler ve değişiklikleri veritabanına kaydeder.
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);     // _dbSet'e entity ekleniyor.
            await _context.SaveChangesAsync();   // Değişiklikler kaydediliyor.
        }

        // Belirtilen id'ye sahip entity'i bulup siler.
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);  // Önce entity bulunuyor.
            if (entity != null)
            {
                _dbSet.Remove(entity);                 // Entity siliniyor.
                await _context.SaveChangesAsync();       // Değişiklikler kaydediliyor.
            }
        }

        // Tüm entity kayıtlarını asenkron olarak liste halinde döndürür.
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();  // Tüm kayıtlar listeye çevrilip döndürülüyor.
        }

        // Belirtilen id'ye sahip entity'i asenkron olarak getirir.
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);  // Entity, id'ye göre bulunuyor.
        }

        // Var olan entity üzerinde güncelleme yapar ve değişiklikleri veritabanına kaydeder.
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);              // Güncelleme işlemi yapılıyor.
            await _context.SaveChangesAsync();  // Değişiklikler kaydediliyor.
        }
    }
}
