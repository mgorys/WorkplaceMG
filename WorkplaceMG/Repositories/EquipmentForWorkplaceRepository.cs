using AutoMapper;
using WorkplaceMG.Entities;
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
    }
}
