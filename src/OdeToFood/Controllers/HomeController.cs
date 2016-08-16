using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers {
	public class HomeController : Controller {
		public IActionResult Index() {
			Restaurant model = new Restaurant() {
				Id = 1,
				Name = "Sabatino's"
			};
			return View(model);
		}
	}
}
