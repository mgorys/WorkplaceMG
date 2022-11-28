using WorkplaceMG.Models.DTOs;
using WorkplaceMG.Repositories.IRepositories;
using WorkplaceMG.Services.IServices;

namespace WorkplaceMG.Services
{
    public class WorkplaceService : IWorkplaceService
    {
        private readonly IWorkplaceRepository _workplaceRepository;

        public WorkplaceService(IWorkplaceRepository workplaceRepository)
        {
            _workplaceRepository = workplaceRepository;
        }
        public IEnumerable<WorkplaceDto> GetAllWorkplaces()
        {
            var result = _workplaceRepository.GetAllWorkplaces();

            return result;
        }
        public List<FloorDto> GetUniqueFloors()
        {
            var result = _workplaceRepository.GetUniqueFloors();

            return result;
        }
        public ReservationDto FindPlace(ReservationDto reservationDto)
        {
            var floor = reservationDto.Floor;
            var room = reservationDto.Room;
            var table = reservationDto.Table;
            reservationDto.IdWorkplace = _workplaceRepository.FindPlace(floor, room, table);
            if (reservationDto.IdWorkplace == 0)
                reservationDto.Message = "Workplace not found";
            return reservationDto;
        }
        
    }
}
