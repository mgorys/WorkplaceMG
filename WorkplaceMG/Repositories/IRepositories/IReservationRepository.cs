using WorkplaceMG.Models.DTOs;

namespace WorkplaceMG.Repositories.IRepositories
{
    public interface IReservationRepository
    {
        IEnumerable<ReservationDto> GetAllReservations(string sortDirect);
        bool CreateReservation(ReservationDto reservationDto);
        List<ReservationDto> GetReservationsById(ReservationDto reservationDto);
        bool DeleteReservation(ReservationDto reservationDto);
        IEnumerable<ReservationDto> GetAllReservationsFiltered(WorkplaceDto workplace);
    }
}