using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers {
	[Route("company/[controller]/[action]")]
	public class AboutController
    {
		public string Phone() {
			return "+1-333-333-333";
		}

		public string Country() {
			return "Ukraine";
		}
    }
}
