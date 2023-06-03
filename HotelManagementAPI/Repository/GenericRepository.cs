using HotelManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementAPI.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		readonly HotelBookingManagementContext _context;

		public GenericRepository(HotelBookingManagementContext context) 
		{
			_context = context;
		}

		private async Task SaveChangesAsync() => await _context.SaveChangesAsync();

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task AddAsync(T data)
		{
			await _context.Set<T>().AddAsync(data);
			await SaveChangesAsync();
		}

		public async Task UpdateAsync(T entity)
		{
			_context.Set<T>().Update(entity);
			await SaveChangesAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			_context.Set<T>().Remove(entity);
			await SaveChangesAsync();
		}
	}
}
