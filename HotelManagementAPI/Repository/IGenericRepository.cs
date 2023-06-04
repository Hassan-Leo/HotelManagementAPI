﻿namespace HotelManagementAPI.Repository
{
	public interface IGenericRepository<T> where T : class
	{
		Task<T> GetByIdAsync(string id);
		Task<IEnumerable<T>> GetAllAsync();
		Task AddAsync(T entity);
		Task DeleteAsync(T entity);
		Task UpdateAsync(T entity);
	}
}
