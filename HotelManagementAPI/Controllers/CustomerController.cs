using AutoMapper;
using HotelManagementAPI.DTOs;
using HotelManagementAPI.Models;
using HotelManagementAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagementAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly ICustomerRepository _customerRepo;
		private readonly IUserRepository _userRepo;
		private readonly IMapper _mapper;

		public CustomersController(ICustomerRepository customerRepo, IUserRepository userRepo, IMapper mapper)
		{
			_customerRepo = customerRepo;
			_userRepo = userRepo;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllRoles()
		{
			return Ok(_userRepo.GetRoles());
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
		public async Task<IActionResult> CreateCustomer([FromBody] CustomerRegisterDTO dto)
		{
			try
			{
				if (ModelState.IsValid)
				{
					Customer customer = _mapper.Map<Customer>(dto);
					ResponseDTO result = await _customerRepo.AddAsync(customer);
					if (result.IsSucessful)
					{
						return StatusCode(201);
					}
					else
					{
						return BadRequest(new { message = "Failed to create a User"});
					}
				}
				else
				{
					return BadRequest()
				}
				
			}
			catch (Exception ex)
			{
				// Log the exception
				return StatusCode(500, "An error occurred while creating the customer.");
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCustomer(string id, CustomerRegisterDTO dto)
		{
			try
			{
				if (id != dto.Id)
					return BadRequest();
				Customer customer = _mapper.Map<Customer>(dto);
				await _customerRepo.UpdateAsync(customer);
				return Ok();
			}
			catch (Exception ex)
			{
				// Log the exception
				return StatusCode(500, "An error occurred while updating the customer.");
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCustomer(string id)
		{
			try
			{
				await _customerRepo.DeleteAsync(await _customerRepo.GetByIdAsync(id));
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
