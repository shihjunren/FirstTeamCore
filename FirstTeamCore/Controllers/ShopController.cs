using Microsoft.AspNetCore.Mvc;

namespace FirstTeamCore.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult ShopOrder()
        {
            return View();
        }

        public IActionResult ShopDetail()
        {
            return View();
        }


    }
}
