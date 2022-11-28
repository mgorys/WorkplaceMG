using WorkplaceMG.Models.DTOs;

namespace WorkplaceMG.Services.IServices
{
    public interface IEquipmentForWorkplaceService
    {
        bool OrderEquimpent(ReservationDto reservationDto);

    }
}