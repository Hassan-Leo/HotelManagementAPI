using HotelManagementAPI.DTOs;

namespace HotelManagementAPI.Repository
{
	public interface IGenericRepository<T> where T : class
	{
		Task<T> GetByIdAsync(string id);
		Task<IEnumerable<T>> GetAllAsync();
		Task<ResponseDTO> AddAsync(T entity);
		Task<ResponseDTO> DeleteAsync(T entity);
		Task<ResponseDTO> UpdateAsync(T entity);
	}
}
