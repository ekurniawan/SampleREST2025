using SampleREST.Services.Models;

namespace SampleREST.Services.DAL
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAll();
        IEnumerable<Employee> GetByName(string name, string city);
        Employee GetEmployee(string id);
        Employee Insert(Employee employee);
        Employee Update(Employee employee);
        void Delete(string id);
    }
}
