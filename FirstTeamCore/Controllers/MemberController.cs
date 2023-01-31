using Microsoft.AspNetCore.Mvc;

namespace FirstTeamCore.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Info()
        {
            return View();
        }

        public IActionResult Review()
        {
            return View();
        }
    }
}
