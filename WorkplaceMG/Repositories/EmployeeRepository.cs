using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WorkplaceMG.Entities;
using WorkplaceMG.Models.DTOs;
using WorkplaceMG.Repositories.IRepositories;

namespace WorkplaceMG.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly WorkplaceDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeRepository(WorkplaceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            try
            {
                var employees = _dbContext.Employees;
                var result = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Problem with database", ex);
            }
        }
        public bool CreateEmployee(EmployeeDto employeeDto)
        {
            try
            {
                var employee = _mapper.Map<Employee>(employeeDto);
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Problem with database", ex);
            }
        }
        public EmployeeDto GetEmployeeById(int id)
        {
            try
            {
                var employee = _dbContext.Employees.FirstOrDefault(x => x.Id == id);
                var employeeDto = _mapper.Map<EmployeeDto>(employee);
                return employeeDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Problem with database", ex);
            }
        }
        public bool UpdateEmployee(EmployeeDto employeeDto, int id)
        {
            try
            {
                var employee = _dbContext.Employees.FirstOrDefault(x => x.Id == id);
                employee.FirstName = employeeDto.FirstName;
                employee.LastName = employeeDto.LastName;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Problem with database", ex);
            }
        }
        public int FindEmployee(string firstName, string lastName)
        {
            try
            {
                var employee = _dbContext.Employees
                    .Where(x => x.LastName == lastName)
                    .FirstOrDefault(x => x.FirstName == firstName);
                if (employee != null)
                {
                    int employeeId = employee.Id;
                    return employeeId;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Problem with database", ex);
            }
        }
    }
}
