using WorkplaceMG.Models.DTOs;

namespace WorkplaceMG.Services.IServices
{
    public interface IEquipmentForWorkplaceService
    {
        ReservationDto OrderEquipment(ReservationDto reservationDto);
        IEnumerable<EquipmentForWorkplaceDto> GetAllEquipmentForWork();

    }
}