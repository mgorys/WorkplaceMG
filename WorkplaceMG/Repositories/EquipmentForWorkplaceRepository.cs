using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkplaceMG.Entities;
using WorkplaceMG.Migrations;
using WorkplaceMG.Models.DTOs;
using WorkplaceMG.Repositories.IRepositories;

namespace WorkplaceMG.Repositories
{
    public class EquipmentForWorkplaceRepository : IEquipmentForWorkplaceRepository
    {
        private readonly WorkplaceDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentForWorkplaceRepository(WorkplaceDbContext dbContext, IMapper mapper,
            IEquipmentRepository equipmentRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _equipmentRepository = equipmentRepository;
        }
        public List<EquipmentForWorkplace> GetEquipmentForWorkplaceById(int id)
        {
            var result =_dbContext.EquipmentForWorkplaces
                .Where(x => x.IdWorkplace == id).ToList();
            return result;
        }
        public IEnumerable<EquipmentForWorkplaceDto> GetAllEquipmentForWorkplace()
        {
            var eqwp = _dbContext.EquipmentForWorkplaces.Include(e=>e.Equipment).Include(w => w.Workplace).ToList();
            var result = _mapper.Map<IEnumerable<EquipmentForWorkplaceDto>>(eqwp);
            return result;
        }
    }
}
