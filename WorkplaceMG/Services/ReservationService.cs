using WorkplaceMG.Entities;
using WorkplaceMG.Models.DTOs;
using WorkplaceMG.Repositories.IRepositories;
using WorkplaceMG.Services.IServices;

namespace WorkplaceMG.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IEquipmentForWorkplaceService _equipmentForWorkplaceService;
        private readonly IEmployeeService _employeeService;
        private readonly IWorkplaceService _workplaceService;

        public ReservationService(IReservationRepository reservationRepository,
            IEquipmentForWorkplaceService equipmentForWorkplaceService,
            IEmployeeService employeeService,
            IWorkplaceService workplaceService)
        {
            _reservationRepository = reservationRepository;
            _equipmentForWorkplaceService = equipmentForWorkplaceService;
            _employeeService = employeeService;
            _workplaceService = workplaceService;
        }
        public IEnumerable<ReservationDto> GetAllReservations(string sortDirect)
        {
            var result = _reservationRepository.GetAllReservations(sortDirect);

            return result;
        }
        public ReservationDto CreateReservation(ReservationDto reservationDto)
        {
            if (reservationDto.TimeTo < reservationDto.TimeFrom)
            {
                reservationDto.Message = "TimeFrom should be earlier than TimeTo";
                return reservationDto;
            }
            DateTime today = DateTime.Today;
            if(reservationDto.TimeTo <= today || reservationDto.TimeFrom <= today)
            {
                reservationDto.Message = "Please make reservation for the future days";
                return reservationDto;
            }

            var datesOccupied = _reservationRepository.GetReservationsById(reservationDto);
            foreach (var item in datesOccupied)
            {
                if (reservationDto.TimeTo > item.TimeFrom && reservationDto.TimeFrom < item.TimeTo)
                {

                    reservationDto.Message = "Your reservation overlapps with other reservation";
                    return reservationDto;
                }
            }
            _employeeService.FindEmployee(reservationDto);

            if (reservationDto.Message != null)
                return reservationDto;

            _workplaceService.FindPlace(reservationDto);

            if (reservationDto.Message != null)
                return reservationDto;

            _equipmentForWorkplaceService.OrderEquipment(reservationDto);

            if (reservationDto.Message != null)
                return reservationDto;

            _reservationRepository.CreateReservation(reservationDto);
            return reservationDto;
        }
        public bool DeleteReservation(ReservationDto reservationdto)
        {
            _reservationRepository.DeleteReservation(reservationdto);
            return true;
        }
        public IEnumerable<ReservationDto> GetAllReservationsFiltered(int floorF, int roomF, int tableF)
        {
            WorkplaceDto workplace = new WorkplaceDto()
            {
                Floor = floorF,
                Room = roomF,
                Table = tableF,
            };
            var result = _reservationRepository.GetAllReservationsFiltered(workplace);
            return result;

        }
    }
}
