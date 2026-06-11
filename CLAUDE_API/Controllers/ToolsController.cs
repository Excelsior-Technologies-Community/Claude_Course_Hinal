using System;
using System.Web.Mvc;
using CLAUDE_API.Model;

namespace CLAUDE_API.Controllers
{
    public class ToolsController : Controller
    {
        private readonly ToolsService _toolsService = new ToolsService();

        public ActionResult Index() => View();
        
        public ActionResult BasicTools() => View();
        
        public ActionResult WebSearch() => View();

        [HttpPost]
        public ActionResult SendBasicTool(string location)
        {
            try
            {
                string text = _toolsService.GetWeatherToolResponse(location ?? "San Francisco, CA");
                return Json(new { success = true, text });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult SendWebSearch(string query)
        {
            try
            {
                string text = _toolsService.GetWebSearchResponse(query ?? "Anthropic Claude");
                return Json(new { success = true, text });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
    }
}
