namespace EmpAPI.Models
{
	public class Employee
	{
		public int Id { get; set; }

		public string? Name { get; set; }
        public string Postition { get; set; }
		
		public double Salary { get; set; }
		public DateTime JoinDate { get; set; }
    }
}
