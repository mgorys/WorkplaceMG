using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkplaceMG.Entities;
using WorkplaceMG.Models.DTOs;
using WorkplaceMG.Repositories.IRepositories;

namespace WorkplaceMG.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly WorkplaceDbContext _dbContext;
        private readonly IMapper _mapper;

        public ReservationRepository(WorkplaceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<ReservationDto> GetAllReservations(string sortDirect)
        {
            try
            {
                var reservations = _dbContext.Reservations
                    .Include(e => e.Employee).Include(w => w.Workplace).OrderBy(x => x.TimeFrom);
                if (sortDirect == "desc")
                {
                    var sorted = reservations.OrderByDescending(x => x.TimeFrom);
                    var resultD = _mapper.Map<IEnumerable<ReservationDto>>(sorted);
                    return resultD;
                }
                var resultA = _mapper.Map<IEnumerable<ReservationDto>>(reservations);

                return resultA;
            }
            catch (Exception ex)
            {
                throw new Exception("Problem with database", ex);
            }
        }
        public bool CreateReservation(ReservationDto reservationDto)
        {
            try
            {
                var reservation = _mapper.Map<Reservation>(reservationDto);
                _dbContext.Reservations.Add(reservation);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Problem with database", ex);
            }
        }
        public List<ReservationDto> GetReservationsById(ReservationDto reservationDto)
        {
            try
            {
                var reservations = _dbContext.Reservations.Where(x => x.Workplace.Floor == reservationDto.Floor)
                    .Where(x => x.Workplace.Room == reservationDto.Room)
                    .Where(x => x.Workplace.Table == reservationDto.Table).ToList();

                var result = _mapper.Map<List<ReservationDto>>(reservations);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Problem with database", ex);
            }
        }
        public bool DeleteReservation(ReservationDto reservationDto)
        {
            try
            {
                var reservation = _mapper.Map<Reservation>(reservationDto);
                _dbContext.Reservations.Remove(reservation);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Problem with database", ex);
            }
        }
        public IEnumerable<ReservationDto> GetAllReservationsFiltered(WorkplaceDto workplace)
        {
            try
            {
                var reservations = _dbContext.Reservations
                    .Include(e => e.Employee)
                    .Include(w => w.Workplace)
                    .Where(x => x.Workplace.Floor == workplace.Floor)
                    .Where(x => x.Workplace.Room == workplace.Room)
                    .Where(x => x.Workplace.Table == workplace.Table)
                    .ToList();

                var result = _mapper.Map<List<ReservationDto>>(reservations);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Problem with database", ex);
            }
        }
    }
}
