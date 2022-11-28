using WorkplaceMG.Models.DTOs;

namespace WorkplaceMG.Repositories.IRepositories
{
    public interface IEmployeeRepository
    {
        bool CreateEmployee(EmployeeDto employeeDto);
        IEnumerable<EmployeeDto> GetAllEmployees();
        EmployeeDto GetEmployeeById(int id);
        bool UpdateEmployee(EmployeeDto employeeDto, int id);
        int FindEmployee(string firstName, string lastName);

    }
}