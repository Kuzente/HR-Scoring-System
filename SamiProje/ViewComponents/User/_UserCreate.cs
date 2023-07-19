using Microsoft.AspNetCore.Mvc;

namespace SamiProje.ViewComponents.User
{
    public class _UserCreate : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
