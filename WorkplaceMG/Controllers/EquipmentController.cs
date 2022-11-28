using Microsoft.AspNetCore.Mvc;
using WorkplaceMG.Services.IServices;

namespace WorkplaceMG.Controllers
{
    public class EquipmentController : Controller
	{
		private readonly IEquipmentService _equipmentService;

		public EquipmentController(IEquipmentService equipmentService)
		{
			_equipmentService = equipmentService;
		}
		public IActionResult Index()
		{
            var result = _equipmentService.EquipmentInStockToday();
            return View(result);
		}
		public IActionResult CheckByDate(DateTime dateOf)
		{
			ViewBag.DateOf = dateOf;
			var result = _equipmentService.EquipmentInStockCheck(dateOf);
            return View("Index", result);
        }

    }
}
