using SampleREST.Services.Models;

namespace SampleREST.Services.DAL
{
    public class EmployeeDAL : IEmployee
    {
        private List<Employee> employees = new List<Employee>();

        public EmployeeDAL()
        {
            employees.Add(new Employee { EmployeeId = 1, EmployeeName = "Erick", City = "Yogyakarta" });
            employees.Add(new Employee { EmployeeId = 2, EmployeeName = "Budi", City = "Jakarta" });
            employees.Add(new Employee { EmployeeId = 3, EmployeeName = "Bambang", City = "Yogyakarta" });
        }



        public IEnumerable<Employee> GetAll()
        {
            return employees;
        }

        public IEnumerable<Employee> GetByName(string name, string city)
        {
            var emp = employees.Where(e => e.EmployeeName.ToLower().Contains(name.ToLower()) &&
              e.City.ToLower().Contains(city.ToLower()));
            return emp;
        }

        public Employee GetEmployee(string id)
        {
            var emp = employees.Where(e => e.EmployeeId == Convert.ToInt32(id)).FirstOrDefault();

            if (emp == null)
            {
                throw new Exception("Employee not found");
            }

            return emp;
        }

        public Employee Insert(Employee employee)
        {
            employees.Add(employee);
            return employee;
        }

        public Employee Update(Employee employee)
        {
            try
            {
                var emp = GetEmployee(employee.EmployeeId.ToString());
                emp.EmployeeName = employee.EmployeeName;
                emp.City = employee.City;
                return emp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(string id)
        {
            try
            {
                var emp = GetEmployee(id);
                employees.Remove(emp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
