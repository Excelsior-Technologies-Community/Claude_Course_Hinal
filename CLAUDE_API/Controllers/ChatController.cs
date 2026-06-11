using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CLAUDE_API.Model;

namespace CLAUDE_API.Controllers
{
    public class ChatController : Controller
    {
        private readonly ClaudeService _claude = new ClaudeService();

        public ActionResult Basic() => View();
        public ActionResult SystemPrompt() => View();
        public ActionResult Temperature() => View();
        public ActionResult Prefill() => View();
        public ActionResult StopSequence() => View();
        public ActionResult Streaming() => View();

        [HttpPost]
        public ActionResult SendBasic()
        {
            try
            {
                var req = RequestHelper.ReadJsonBody<ChatRequest>();
                string text = _claude.BasicChatAsync(
                    req.Messages ?? new List<ChatMessage>(),
                    req.SystemPrompt,
                    req.Temperature);

                return Json(new { success = true, text });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult SendTemperature()
        {
            try
            {
                var req = RequestHelper.ReadJsonBody<ChatRequest>();
                string text = _claude.TemperatureChatAsync(
                    req.Messages ?? new List<ChatMessage>(),
                    req.SystemPrompt,
                    req.Temperature);

                return Json(new { success = true, text });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult SendPrefill()
        {
            try
            {
                var req = RequestHelper.ReadJsonBody<ChatRequest>();
                string text = _claude.PrefillChatAsync(
                    req.Messages ?? new List<ChatMessage>(),
                    req.Prefill,
                    req.StopSequences,
                    req.SystemPrompt,
                    req.Temperature);

                return Json(new { success = true, text });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult SendStopSequence()
        {
            try
            {
                var req = RequestHelper.ReadJsonBody<ChatRequest>();
                string text = _claude.StopSequenceChatAsync(
                    req.Messages ?? new List<ChatMessage>(),
                    req.StopSequences,
                    req.Prefill,
                    req.SystemPrompt,
                    req.Temperature);

                return Json(new { success = true, text });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult SendStreaming()
        {
            try
            {
                var req = RequestHelper.ReadJsonBody<ChatRequest>();
                string text = _claude.StreamingChatAsync(
                    req.Messages ?? new List<ChatMessage>(),
                    req.SystemPrompt,
                    req.Temperature);

                return Json(new { success = true, text });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
    }
}
