namespace SampleREST.Services.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string? City { get; set; }
    }
}
