using EmpAPI.Models;
using System.Diagnostics.Contracts;


namespace EmpAPI.Services
{
	public static class EmployeeBusiness
	{
		static List<Employee> emps;
		static int newid = 7;

		static EmployeeBusiness()
		{
			emps = new List<Employee>
			{
				new Employee {Id=1, Name="Rajat", Postition="JSD", Salary=35000, JoinDate = new DateTime(2024, 01, 25)},
				new Employee {Id=2, Name="Salony", Postition="JSD", Salary=35000, JoinDate = new DateTime(2024, 02, 25)},
				new Employee {Id=3, Name="Ashutosh", Postition="SSD", Salary=40000, JoinDate = new DateTime(2024, 03, 25)},
				new Employee {Id=4, Name="Manas", Postition="SSD", Salary=50000, JoinDate = new DateTime(2024, 04, 25)},
				new Employee {Id=5, Name="Prajyot", Postition="CSO", Salary=45000, JoinDate = new DateTime(2024, 05, 25)},
				new Employee {Id=6, Name="Rajat", Postition="CSO", Salary=45000, JoinDate = new DateTime(2024, 06, 25)}
			};
		}

		// GET REQUEST METHODS
		public static List<Employee> GetAll() => emps;

		public static Employee? GetById(int id) => emps.Find(e => e.Id == id);
		public static Employee? GetByDate(DateTime dt) => emps.FirstOrDefault(emp => emp.JoinDate == dt);
		public static Employee GetSecondHighest()
		{
			List<Employee> temp = new List<Employee>(emps);
			temp.Sort((a, b) => b.Salary.CompareTo(a.Salary));	// this needs attention
			for(int i = 1; i < temp.Count; i++)
			{
				if (emps[i].Salary < emps[i - 1].Salary) return emps[i];
			}

			return null!;
		}
		//POST REQUEST METHOD
		public static void Add(Employee e)
		{
			e.Id = newid++;
			emps.Add(e);
		}

		//PUT(UPDATE) REQUEST METHOD
		public static void Update(Employee e)
		{
			var i = emps.FindIndex(p => p.Id == e.Id);
			if (i == -1) return;

			emps[i] = e;
		}

		//DELETE REQUEST METHOD
		public static void Delete(int id)
		{
			var e = GetById(id);
			if (e == null) return;

			emps.Remove(e);
		}
	}
}
