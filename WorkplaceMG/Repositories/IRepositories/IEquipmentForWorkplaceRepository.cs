using WorkplaceMG.Entities;
using WorkplaceMG.Models.DTOs;

namespace WorkplaceMG.Repositories.IRepositories
{
    public interface IEquipmentForWorkplaceRepository
    {
        List<EquipmentForWorkplace> GetEquipmentForWorkplaceById(int id);
    }
}