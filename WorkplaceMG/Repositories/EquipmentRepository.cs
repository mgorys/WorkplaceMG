using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkplaceMG.Entities;
using WorkplaceMG.Models.DTOs;
using WorkplaceMG.Repositories.IRepositories;

namespace WorkplaceMG.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly WorkplaceDbContext _dbContext;
        private readonly IMapper _mapper;

        public EquipmentRepository(WorkplaceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<EquipmentDto> GetAllEquipment()
        {
            try
            {
                var equipment = _dbContext.Equipments;
                var result = _mapper.Map<IEnumerable<EquipmentDto>>(equipment);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Problem with database", ex);
            }
        }

        public IEnumerable<EquipmentForDayDto> EquipmentOrganizer(DateTime date)
        {
            try
            {
                List<Equipment> equipment = new List<Equipment>();
                equipment = _dbContext.Equipments.ToList();
                var equipmentForDayDto = _mapper.Map<IEnumerable<EquipmentForDayDto>>(equipment);
                foreach (var item in equipmentForDayDto)
                {
                    item.Date = date;
                }
                var eqForWorkplace = _dbContext.EquipmentForWorkplaces.ToList();
                var reservations = _dbContext.Reservations.ToList();
                foreach (var singleRes in reservations)
                {
                    if (singleRes.TimeFrom <= date && date <= singleRes.TimeTo)
                    {
                        foreach (var item in eqForWorkplace)
                        {
                            if (singleRes.IdWorkplace == item.IdWorkplace)
                            {
                                foreach (var eq in equipmentForDayDto)
                                {
                                    if (item.IdEquipment == eq.Id)
                                    {
                                        eq.StockCount -= 1;
                                    }
                                }
                            }
                        }
                    }
                }
                return equipmentForDayDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Problem with database", ex);
            }
        }
    }
}
