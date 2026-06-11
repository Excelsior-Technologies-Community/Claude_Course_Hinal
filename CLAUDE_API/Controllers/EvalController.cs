using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CLAUDE_API.Models;

namespace CLAUDE_API.Controllers
{
    public class EvalController : Controller
    {
        private readonly EvalService _evalService = new EvalService();

        public ActionResult Index() => View();
        public ActionResult Dataset() => View();

        // POST: Generate Dataset (static)
        [HttpPost]
        public ActionResult GenerateDataset(GenerateDatasetRequest req)
        {
            try
            {
                if (req.PromptInputsSpec == null)
                    req.PromptInputsSpec = new Dictionary<string, string>();

                var dataset = _evalService.GenerateDataset(
                    req.TaskDescription,
                    req.PromptInputsSpec,
                    req.NumCases);

                return Json(new { success = true, data = dataset });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        // POST: Run Evaluation (static)
        [HttpPost]
        public ActionResult RunEvaluation(RunEvaluationRequest req)
        {
            try
            {
                var summary = _evalService.RunEvaluation(
                    req.Dataset,
                    req.PromptTemplate,
                    req.ExtraCriteria);

                return Json(new { success = true, data = summary });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
    }
}