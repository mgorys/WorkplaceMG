using WorkplaceMG.Models.DTOs;

namespace WorkplaceMG.Repositories.IRepositories
{
    public interface IEquipmentRepository
    {
        IEnumerable<EquipmentForDayDto> EquipmentOrganizer(DateTime date);
        IEnumerable<EquipmentDto> GetAllEquipment();
    }
}