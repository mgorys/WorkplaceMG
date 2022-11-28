using Microsoft.AspNetCore.Mvc;
using WorkplaceMG.Models.DTOs;
using WorkplaceMG.Services.IServices;

namespace WorkplaceMG.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        public IActionResult Index(string sortDirect)
        {
            var result = _reservationService.GetAllReservations(sortDirect);
            return View(result);
        }
        public IActionResult Filter(int floorF, int roomF, int tableF)
        {
            var result = _reservationService.GetAllReservationsFiltered(floorF, roomF, tableF);
            return View("Index",result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReservationDto reservation)
        {
            //if (ModelState.IsValid)
            {
                _reservationService.CreateReservation(reservation);
                if (reservation.Message is null)
                {
                    TempData["success"] = "Reservation created successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["success"] = reservation.Message;
                }
            }

            return View(reservation);
        }
        public IActionResult Delete(ReservationDto reservation)
        {
            {
                _reservationService.DeleteReservation(reservation);
            }
            return RedirectToAction("Index");
        }
    }
}
