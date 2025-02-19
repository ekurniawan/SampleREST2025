using Dapper;
using Microsoft.Data.SqlClient;
using SampleREST.Services.Models;
using System.Transactions;

namespace SampleREST.Services.DAL
{
    public class EmployeeDapper : IEmployee
    {
        private readonly IConfiguration _configuration;
        public EmployeeDapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }


        public void Delete(string id)
        {

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"DELETE FROM Employees WHERE EmployeeId = @EmployeeId";
                var param = new { EmployeeId = id };
                try
                {
                    var result = conn.Execute(strSql, param);
                    if (result <= 0)
                    {
                        throw new Exception("Employee not found");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"SELECT EmployeeId, EmployeeName, City FROM Employees
                                  order by EmployeeName asc";
                var results = conn.Query<Employee>(strSql);
                return results;
            }
        }

        public IEnumerable<Employee> GetByName(string name, string city)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"SELECT EmployeeId, EmployeeName, City FROM Employees
                                  where EmployeeName like @EmployeeName and City like @City
                                  order by EmployeeName asc";
                var param = new { EmployeeName = "%" + name + "%", City = "%" + city + "%" };
                var results = conn.Query<Employee>(strSql, param);
                return results;
            }
        }

        public Employee GetEmployee(string id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"SELECT EmployeeId, EmployeeName, City FROM Employees
                                  WHERE EmployeeId = @EmployeeId";
                var param = new { EmployeeId = id };
                var result = conn.QueryFirstOrDefault<Employee>(strSql, param);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Employee not found");
                }
            }
        }

        public Employee Insert(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"INSERT INTO Employees (EmployeeName, City)
                                  VALUES (@EmployeeName, @City);select @@identity";
                var param = new { EmployeeName = employee.EmployeeName, City = employee.City };
                try
                {
                    var id = conn.ExecuteScalar<int>(strSql, param);
                    employee.EmployeeId = id;
                    return employee;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public Employee Update(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"UPDATE Employees SET EmployeeName = @EmployeeName, City = @City
                                  WHERE EmployeeId = @EmployeeId";
                var param = new { EmployeeId = employee.EmployeeId, EmployeeName = employee.EmployeeName, City = employee.City };
                try
                {
                    var result = conn.Execute(strSql, param);
                    if (result <= 0)
                    {
                        throw new Exception("Employee not found");
                    }
                    return employee;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
