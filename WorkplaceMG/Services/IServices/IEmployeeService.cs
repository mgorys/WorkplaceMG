using WorkplaceMG.Models.DTOs;

namespace WorkplaceMG.Services.IServices
{
    public interface IEmployeeService
    {
        bool CreateEmployee(EmployeeDto employeeDto);
        IEnumerable<EmployeeDto> GetAllEmployees();
        EmployeeDto GetEmployeeById(int id);
        bool UpdateEmployee(EmployeeDto employeeDto);
        ReservationDto FindEmployee(ReservationDto reservationDto);

    }
}