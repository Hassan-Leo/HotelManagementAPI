using HotelManagementAPI.DTOs;
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

		public async Task<T> GetByIdAsync(string id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<ResponseDTO> AddAsync(T entity)
		{
			if (entity != null)
			{
				await _context.Set<T>().AddAsync(entity);
				await SaveChangesAsync();
				return new ResponseDTO
				{
					IsSucessful = true
				};
			}
			else
			{
				return new ResponseDTO
				{
					IsSucessful = false
				};
			}
		}

		public async Task<ResponseDTO> UpdateAsync(T entity)
		{
			if(entity != null)
			{
				_context.Set<T>().Update(entity);
				await SaveChangesAsync();
				return new ResponseDTO
				{
					IsSucessful = true
				};
			}
			else
			{
				return new ResponseDTO
				{
					IsSucessful = false
				};
			}
		}

		public async Task<ResponseDTO> DeleteAsync(T entity)
		{
			if (entity != null)
			{
				_context.Set<T>().Remove(entity);
				await SaveChangesAsync();
				return new ResponseDTO
				{
					IsSucessful = true
				};
			}
			else
			{
				return new ResponseDTO
				{
					IsSucessful = false
				};
			}
		}
	}
}
