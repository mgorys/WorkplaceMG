using Microsoft.EntityFrameworkCore;
using WorkplaceMG.Models.DTOs;
using WorkplaceMG.Repositories;
using WorkplaceMG.Repositories.IRepositories;
using WorkplaceMG.Services.IServices;

namespace WorkplaceMG.Services
{
    public class EquipmentForWorkplaceService : IEquipmentForWorkplaceService
	{
		private readonly IEquipmentForWorkplaceRepository _equipmentForWorkplaceRepository;
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentForWorkplaceService(IEquipmentForWorkplaceRepository equipmentForWorkplaceRepository, 
            IEquipmentRepository equipmentRepository)
		{
			_equipmentForWorkplaceRepository = equipmentForWorkplaceRepository;
            _equipmentRepository = equipmentRepository;
        }
		public ReservationDto OrderEquipment(ReservationDto reservationDto)
        {
            try
            {
                List<DateTime> days = new List<DateTime>();
                List<IEnumerable<EquipmentForDayDto>> eqPerDay = new List<IEnumerable<EquipmentForDayDto>>();
                DateTime dayFrom = (DateTime)reservationDto.TimeFrom;
                DateTime dayTo = (DateTime)reservationDto.TimeTo;
                List<string> errors = new List<string>();
                for (DateTime i = dayFrom; i <= dayTo; i = i.AddDays(1))
                {
                    days.Add(i);
                    eqPerDay.Add(_equipmentRepository.EquipmentOrganizer(i));
                }
                int id = reservationDto.IdWorkplace;
                var eqForWorkplace = _equipmentForWorkplaceRepository.GetEquipmentForWorkplaceById(id);
                    
                foreach (var day in eqPerDay)
                {
                    foreach (var item in day)
                    {
                        foreach (var eq in eqForWorkplace)
                        {
                            if (eq.IdEquipment == item.Id)
                            {
                                if (item.StockCount < 1)
                                {
                                    errors.Add(item.Type);
                                }
                            }
                        }
                    }
                }
                errors = errors.Distinct().ToList();
                if (errors.Count > 0)
                {
                    reservationDto.Message = "There will be no equipment in stock to make reservation. Missing items: ";
                    foreach (var item in errors)
                    {
                        reservationDto.Message += item.ToString() + " ";
                    }
                }
                return reservationDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Problem with database", ex);
            }
        }
    }
}
