using System;
using System.Web.Mvc;
using CLAUDE_API.Model;

namespace CLAUDE_API.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly FeaturesService _featuresService = new FeaturesService();

        public ActionResult Index() => View();
        
        public ActionResult Thinking() => View();
        
        public ActionResult Images() => View();

        [HttpPost]
        public ActionResult SendThinking(string input)
        {
            try
            {
                string text = _featuresService.GetThinkingResponse(input ?? "Hello");
                return Json(new { success = true, text });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult SendImage(string imageName)
        {
            try
            {
                string text = _featuresService.GetImageAnalysisResponse(imageName ?? "unknown.jpg");
                return Json(new { success = true, text });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
    }
}
