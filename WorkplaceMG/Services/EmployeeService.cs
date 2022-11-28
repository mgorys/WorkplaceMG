using WorkplaceMG.Models.DTOs;
using WorkplaceMG.Repositories.IRepositories;
using WorkplaceMG.Services.IServices;

namespace WorkplaceMG.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var result = _repository.GetAllEmployees();

            return result;
        }
        public bool CreateEmployee(EmployeeDto employeeDto)
        {
            var result = _repository.CreateEmployee(employeeDto);
            return result;
        }
        public EmployeeDto GetEmployeeById(int id)
        {
            var result = _repository.GetEmployeeById(id);
            return result;
        }
        public bool UpdateEmployee(EmployeeDto employeeDto)
        {
            int id = employeeDto.Id;
            _repository.UpdateEmployee(employeeDto, id);
            return true;
        }
        public ReservationDto FindEmployee(ReservationDto reservationDto)
        {
            var firstName = reservationDto.FirstName;
            var lastName = reservationDto.LastName;
            reservationDto.IdEmployee = _repository.FindEmployee(firstName, lastName);
            if(reservationDto.IdEmployee == 0)
            {
                reservationDto.Message = "Employee not found. Check if proper name and surname are given.";
            }
            return reservationDto;
        }
    }
}
