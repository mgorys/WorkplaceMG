using WorkplaceMG.Models.DTOs;

namespace WorkplaceMG.Services.IServices
{
    public interface IWorkplaceService
    {
        IEnumerable<WorkplaceDto> GetAllWorkplaces();
        List<FloorDto> GetUniqueFloors();
        ReservationDto FindPlace(ReservationDto reservationDto);
    }
}