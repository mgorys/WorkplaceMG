using WorkplaceMG.Models.DTOs;

namespace WorkplaceMG.Repositories.IRepositories
{
    public interface IWorkplaceRepository
    {
        IEnumerable<WorkplaceDto> GetAllWorkplaces();
        List<FloorDto> GetUniqueFloors();
        int FindPlace(int floor, int room, int table);

    }
}