using AutoMapper;
using WorkplaceMG.Entities;
using WorkplaceMG.Models.DTOs;

namespace WorkplaceMG.Models.Profiles
{
    public class WorkplaceMappingProfile : Profile
    {
        public WorkplaceMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<WorkplaceDto, Workplace>();
            CreateMap<Workplace, WorkplaceDto>();
            CreateMap<EquipmentDto, Equipment>();
            CreateMap<Equipment, EquipmentDto>();
            CreateMap<EquipmentForDayDto, EquipmentDto>();
            CreateMap<Equipment, EquipmentForDayDto>();

            CreateMap<ReservationDto, Reservation>();
              
                

            CreateMap<Reservation, ReservationDto>()
                .ForMember(m => m.FirstName, n => n.MapFrom(b => b.Employee.FirstName))
                .ForMember(m => m.LastName, n => n.MapFrom(b => b.Employee.LastName))
                .ForMember(m => m.Floor, n => n.MapFrom(b => b.Workplace.Floor))
                .ForMember(m => m.Table, n => n.MapFrom(b => b.Workplace.Table))
                .ForMember(m => m.Room, n => n.MapFrom(b => b.Workplace.Room));
        }
    }
}
