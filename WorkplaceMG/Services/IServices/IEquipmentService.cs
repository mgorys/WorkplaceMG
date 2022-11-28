using WorkplaceMG.Models.DTOs;

namespace WorkplaceMG.Services.IServices
{
    public interface IEquipmentService
    {
        IEnumerable<EquipmentDto> GetAllEquipment();
        IEnumerable<EquipmentDto> EquipmentInStockToday();
        IEnumerable<EquipmentDto> EquipmentInStockCheck(DateTime dateOf);
    }
}