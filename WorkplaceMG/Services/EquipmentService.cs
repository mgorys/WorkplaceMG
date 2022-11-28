using AutoMapper;
using WorkplaceMG.Entities;
using WorkplaceMG.Models.DTOs;
using WorkplaceMG.Repositories.IRepositories;
using WorkplaceMG.Services.IServices;

namespace WorkplaceMG.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IMapper _mapper;

        public EquipmentService(IEquipmentRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }
        public IEnumerable<EquipmentDto> GetAllEquipment()
        {
            var result = _equipmentRepository.GetAllEquipment();

            return result;
        }
        public IEnumerable<EquipmentDto> EquipmentInStockToday()
        {
            DateTime today = DateTime.Today;
            var result = _equipmentRepository.EquipmentOrganizer(today);
            var equipment = _mapper.Map<IEnumerable<EquipmentDto>>(result);
            return equipment;
        }
        public IEnumerable<EquipmentDto> EquipmentInStockCheck(DateTime dateOf)
        {
            var result = _equipmentRepository.EquipmentOrganizer(dateOf);
            var equipment = _mapper.Map<IEnumerable<EquipmentDto>>(result);
            return equipment;
        }
    }
}
