using System;
using System.Collections.Generic;
using System.Linq;

namespace CLAUDE_API.Model
{
    /// <summary>
    /// Static implementation of the Python chat() function — no API calls.
    /// </summary>
    public class ClaudeService
    {
        private static readonly Random _random = new Random();

        public string Chat(
            List<ChatMessage> messages,
            string system = null,
            double temperature = 1.0,
            string prefill = null,
            List<string> stopSequences = null)
        {
            string raw = ResolveStaticResponse(messages, system, temperature, prefill);
            return ApplyStopSequences(raw, stopSequences);
        }

        public string BasicChatAsync(List<ChatMessage> messages, string systemPrompt = null, double temperature = 1.0)
        {
            return Chat(messages, systemPrompt, temperature);
        }

        public string TemperatureChatAsync(List<ChatMessage> messages, string systemPrompt = null, double temperature = 1.0)
        {
            return Chat(messages, systemPrompt, temperature);
        }

        public string PrefillChatAsync(
            List<ChatMessage> messages,
            string prefill = null,
            List<string> stopSequences = null,
            string systemPrompt = null,
            double temperature = 1.0)
        {
            return Chat(messages, systemPrompt, temperature, prefill, stopSequences);
        }

        public string StopSequenceChatAsync(
            List<ChatMessage> messages,
            List<string> stopSequences = null,
            string prefill = null,
            string systemPrompt = null,
            double temperature = 1.0)
        {
            return Chat(messages, systemPrompt, temperature, prefill, stopSequences);
        }

        public string StreamingChatAsync(List<ChatMessage> messages, string systemPrompt = null, double temperature = 1.0)
        {
            return Chat(messages, systemPrompt, temperature);
        }

        private static string ResolveStaticResponse(
            List<ChatMessage> messages,
            string system,
            double temperature,
            string prefill)
        {
            string lastUser = ChatHelpers.GetLastUserMessage(messages) ?? string.Empty;
            string normalized = lastUser.Trim().ToLowerInvariant();

            // Task 4 — EventBridge JSON with ```json prefill
            if (!string.IsNullOrEmpty(prefill) && prefill.Contains("```json"))
            {
                return StaticChatData.EventBridgeJson;
            }

            // Task 5 — AWS CLI commands (prefill or prompt match)
            if ((!string.IsNullOrEmpty(prefill) && prefill.Contains("```bash")) ||
                normalized.Contains("aws cli"))
            {
                return StaticChatData.AwsCliResponse;
            }

            // Task 4 — EventBridge JSON (prompt match without prefill)
            if (normalized.Contains("event bridge") || normalized.Contains("eventbridge"))
            {
                return StaticChatData.EventBridgeJson;
            }

            // Task 2 — system prompt: concise Python engineer
            if (!string.IsNullOrEmpty(system) &&
                system.IndexOf("python", StringComparison.OrdinalIgnoreCase) >= 0 &&
                normalized.Contains("duplicate"))
            {
                return StaticChatData.DuplicateCharsResponse;
            }

            // Task 3 — temperature-controlled movie idea
            if (normalized.Contains("movie idea") || normalized.Contains("one sentence movie"))
            {
                if (temperature <= 0.0)
                    return StaticChatData.MovieIdeaDeterministic;

                var ideas = StaticChatData.MovieIdeasCreative;
                return ideas[_random.Next(ideas.Length)];
            }

            // Task 6 — fake database description
            if (normalized.Contains("fake database") || normalized.Contains("database"))
            {
                return StaticChatData.FakeDatabaseResponse;
            }

            // Task 1 — basic multi-turn chat
            foreach (var pair in StaticChatData.BasicResponses)
            {
                if (normalized.Contains(pair.Key))
                    return pair.Value;
            }

            if (messages != null && messages.Count(m => m.Role == "user") > 1)
            {
                return "I remember our earlier messages. This static demo keeps the full conversation history " +
                       "just like the Python messages list.";
            }

            return StaticChatData.BasicDefaultResponse;
        }

        private static string ApplyStopSequences(string text, List<string> stopSequences)
        {
            if (string.IsNullOrEmpty(text) || stopSequences == null || stopSequences.Count == 0)
                return text;

            int cutAt = text.Length;
            foreach (var stop in stopSequences.Where(s => !string.IsNullOrEmpty(s)))
            {
                int idx = text.IndexOf(stop, StringComparison.Ordinal);
                if (idx >= 0 && idx < cutAt)
                    cutAt = idx;
            }

            return text.Substring(0, cutAt).TrimEnd();
        }
    }
}
