using EmpAPI.Models;
using EmpAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;

namespace EmpAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		public EmployeeController()
		{
		}

		/*************************************************************
		                           GET ACTIONS
								1. GET ALL LIST NAMES
								2. GET EMPLOYEE WITH SECOND HIGHEST SALARY
								3. GET EMPLOYEE BY ID
								4. GET EMPLOYEE BY JOINING DATE
		 ************************************************************/
		//GET ALL
		[HttpGet]
		public ActionResult<List<Employee>> GetList()
		{
			return EmployeeBusiness.GetAll();
		}

		//GET EMPLOYEE WITH SECOND HIGHEST SALARY
		[HttpGet("GetSecondHighest")]
		public ActionResult<Employee> GetSecondHighest()
		{
			return EmployeeBusiness.GetSecondHighest();
		}

		//GET EMPLOYEE BY ID
		[HttpGet("{id}")]
		public ActionResult<Employee> GetById(int id)
		{
			var emp = EmployeeBusiness.GetById(id);
			if (emp == null) return NotFound();
			return emp;
		}

		//GET EMPLOYEE BY JOINING DATE
		[HttpGet("GetByDate/{dt}")]
		public ActionResult<Employee> GetByDate(DateTime dt)
		{
			var emp = EmployeeBusiness.GetByDate(dt);
			if (emp == null) return NotFound();
			return emp;
		}

		/*******************************************************
						POST REQUEST ACTION
						Create a new entry
		*******************************************************/
		[HttpPost]
		public IActionResult Add(Employee e)
		{
			EmployeeBusiness.Add(e);
			return CreatedAtAction("GetById", new { id = e.Id }, e);
		}

		/*******************************************************
						PUT REQUEST ACTION
					 Update an existing entry
		*******************************************************/
		[HttpPut]
		public IActionResult Update(int id, Employee emp)
		{
			if (id != emp.Id) return BadRequest();

			var prev = EmployeeBusiness.GetById(id);
			if (prev is null) return NotFound();

			EmployeeBusiness.Update(emp);
			return NoContent();
		}

		/*******************************************************
						DELETE REQUEST ACTION
						   Delete a entry
		*******************************************************/
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var emp = EmployeeBusiness.GetById(id);
			if (emp==null) return NotFound();

			EmployeeBusiness.Delete(id);
			return NoContent();
		}
	}
}
