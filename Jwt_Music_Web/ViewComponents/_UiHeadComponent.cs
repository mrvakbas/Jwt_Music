using Microsoft.AspNetCore.Mvc;

namespace Jwt_Music_Web.ViewComponents
{
    public class _UiHeadComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
