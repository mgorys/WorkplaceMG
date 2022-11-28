using WorkplaceMG.Models.DTOs;
using WorkplaceMG.Repositories.IRepositories;
using WorkplaceMG.Services.IServices;

namespace WorkplaceMG.Services
{
    public class EquipmentForWorkplaceService : IEquipmentForWorkplaceService
	{
		private readonly IEquipmentForWorkplaceRepository _equipmentForWorkplaceRepository;

		public EquipmentForWorkplaceService(IEquipmentForWorkplaceRepository equipmentForWorkplaceRepository)
		{
			_equipmentForWorkplaceRepository = equipmentForWorkplaceRepository;
		}
		public bool OrderEquimpent(ReservationDto reservationDto)
		{
			_equipmentForWorkplaceRepository.OrderEquipment(reservationDto);

            return true;
		}
	}
}
