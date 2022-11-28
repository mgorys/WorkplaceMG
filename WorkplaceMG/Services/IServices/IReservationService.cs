using WorkplaceMG.Models.DTOs;

namespace WorkplaceMG.Services.IServices
{
    public interface IReservationService
    {
        IEnumerable<ReservationDto> GetAllReservations(string sortDirect);
        ReservationDto CreateReservation(ReservationDto reservationDto);
        IEnumerable<ReservationDto> GetAllReservationsFiltered(int floorF, int roomF, int tableF);
        bool DeleteReservation(ReservationDto reservation);
    }
}