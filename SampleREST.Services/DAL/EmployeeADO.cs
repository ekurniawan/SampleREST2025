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
            List<Employee> employees = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"SELECT EmployeeId, EmployeeName, City FROM Employees
                                  where EmployeeName like @EmployeeName and City like @City
                                  order by EmployeeName asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@EmployeeName", "%" + name + "%");
                cmd.Parameters.AddWithValue("@City", "%" + city + "%");
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                        employee.EmployeeName = reader["EmployeeName"].ToString();
                        employee.City = reader["City"].ToString();
                        employees.Add(employee);
                    }
                }
                reader.Close();
                cmd.Dispose();
                conn.Close();
            }
            return employees;
        }

        public Employee GetEmployee(string id)
        {
            Employee employee = new Employee();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"SELECT EmployeeId, EmployeeName, City FROM Employees
                                  where EmployeeId = @EmployeeId";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@EmployeeId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    employee.EmployeeName = reader["EmployeeName"].ToString();
                    employee.City = reader["City"].ToString();
                }
                reader.Close();
                cmd.Dispose();
                conn.Close();
            }
            return employee;
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
