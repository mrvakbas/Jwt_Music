using Microsoft.AspNetCore.Mvc;

namespace Jwt_Music_Web.ViewComponents
{
    public class _UiFooterComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
