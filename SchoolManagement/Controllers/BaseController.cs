using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SchoolManagement.Services;

namespace SchoolManagement.Controllers
{

    public class BaseController(ISessionYearService sessionYearService) : Controller
    {
        public readonly ISessionYearService _sessionYearService = sessionYearService;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            SetSelectedSessionTempData();
        }
        public async Task<string> GetActiveSession()
        {
            var sessionYear = await _sessionYearService.GetActiveSessionYear();
            return "Session - " + sessionYear.SessionName;
        }
        public void SetSelectedSessionTempData()
        {

            var data = _sessionYearService.GetSelectedSession();
            if (data != null)
            {
                TempData["SelectedSession"] = JsonConvert.SerializeObject(data);
            }
        }
    }
}
