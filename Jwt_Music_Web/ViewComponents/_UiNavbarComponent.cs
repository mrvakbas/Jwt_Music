using Microsoft.AspNetCore.Mvc;

namespace Jwt_Music_Web.ViewComponents
{
    public class _UiNavbarComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
