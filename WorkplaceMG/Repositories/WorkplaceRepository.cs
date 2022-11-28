using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing;
using WorkplaceMG.Entities;
using WorkplaceMG.Models.DTOs;
using WorkplaceMG.Repositories.IRepositories;

namespace WorkplaceMG.Repositories
{
    public class WorkplaceRepository : IWorkplaceRepository
    {
        private readonly WorkplaceDbContext _dbContext;
        private readonly IMapper _mapper;

        public WorkplaceRepository(WorkplaceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<WorkplaceDto> GetAllWorkplaces()
        {
            try
            {
                var workplaces = _dbContext.Workplaces;
                var result = _mapper.Map<IEnumerable<WorkplaceDto>>(workplaces);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<FloorDto> GetUniqueFloors()
        {
            try
            {
                List<FloorDto> listOfFloors = new List<FloorDto>();
                var floors = _dbContext.Workplaces.Select(m => m.Floor).Distinct().ToList();

                foreach (var floor in floors)
                {
                    FloorDto floorDto = new FloorDto()
                    {
                        Id = floor,
                        RoomList = new List<RoomDto>()
                    };
                    var rooms = _dbContext.Workplaces.Where(m => m.Floor == floor).Select(m => m.Room).Distinct().ToList();
                    foreach (var room in rooms)
                    {
                        var roomdto = new RoomDto()
                        {
                            Id = room,
                            TableList = new List<int>()

                        };
                        var tables = _dbContext.Workplaces.Where(m => m.Room == room && m.Floor == floor).Select(m => m.Table).Distinct().ToList();
                        roomdto.TableList.AddRange(tables);
                        floorDto.RoomList.Add(roomdto);
                    }
                    listOfFloors.Add(floorDto);
                }

                return listOfFloors;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int FindPlace(int floor,int room,int table)
        {
            var place = _dbContext.Workplaces
                .Where(x => x.Floor == floor)
                .Where(x=>x.Room==room)
                .FirstOrDefault(x => x.Table == table);
            if (place != null)
            {
                int placeId = place.Id;
                return placeId;
            }
            else
            {
                return 0;
            }
        }
    }
}
