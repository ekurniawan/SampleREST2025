using Microsoft.Data.SqlClient;
using SampleREST.Services.Models;

namespace SampleREST.Services.DAL
{
    public class EmployeeADO : IEmployee
    {
        private readonly IConfiguration _configuration;
        public EmployeeADO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            Employee employee;
            List<Employee> employees = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"SELECT EmployeeId, EmployeeName, City FROM Employees
                                  order by EmployeeName asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employee = new Employee();
                        employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                        employee.EmployeeName = reader["EmployeeName"].ToString();
                        employee.City = reader["City"].ToString();
                        employees.Add(employee);
                    }
                }
                reader.Close();

                cmd.Dispose();
                conn.Close();

                return employees;
            }
        }

        public IEnumerable<Employee> GetByName(string name, string city)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(string id)
        {
            throw new NotImplementedException();
        }

        public Employee Insert(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee employee)
        {
            throw new NotImplementedException();
        }


    }
}
