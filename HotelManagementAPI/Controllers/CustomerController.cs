using AutoMapper;
using HotelBookingManagement.DataAccess;
using HotelBookingManagement.Models;
using HotelManagementAPI.DTOs;
using HotelManagementAPI.Models;
using HotelManagementAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly ICustomerRepository _customerRepo;

		public CustomersController(ICustomerRepository customerRepo)
		{
			_customerRepo = customerRepo;
		}

		[HttpGet]
		public async Task<ActionResult<List<Customer>>> GetCustomers()
		{
			try
			{
				var customers = await _customerRepo.GetAllAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				// Log the exception
				return StatusCode(500, "An error occurred while retrieving customers.");
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Customer>> GetCustomer(string id)
		{
			try
			{
				var customer = await _customerRepo.GetByIdAsync(id);
				if (customer == null)
					return NotFound();

				return Ok(customer);
			}
			catch (Exception ex)
			{
				// Log the exception
				return StatusCode(500, "An error occurred while retrieving the customer.");
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateCustomer([FromBody] CustomerDTO dto)
		{
			try
			{
				Customer customer = Mapper.Map<Customer>(dto);
				await _customerRepo.AddAsync(customer);
				return Ok();
			}
			catch (Exception ex)
			{
				// Log the exception
				return StatusCode(500, "An error occurred while creating the customer.");
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCustomer(string id, CustomerDTO customer)
		{
			try
			{
				if (id != customer.CustomerId)
					return BadRequest();

				await _customerDataAccess.UpdateCustomerAsync(customer);
				return Ok();
			}
			catch (Exception ex)
			{
				// Log the exception
				return StatusCode(500, "An error occurred while updating the customer.");
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCustomer(int id)
		{
			try
			{
				await _customerDataAccess.DeleteCustomerAsync(id);
				return Ok();
			}
			catch (Exception ex)
			{
				// Log the exception
				return StatusCode(500, "An error occurred while deleting the customer.");
			}
		}
	}

}
