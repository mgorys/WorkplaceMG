using WorkplaceMG.Models.DTOs;

namespace WorkplaceMG.Repositories.IRepositories
{
    public interface IEquipmentForWorkplaceRepository
    {
        ReservationDto OrderEquipment(ReservationDto reservationDto);
    }
}