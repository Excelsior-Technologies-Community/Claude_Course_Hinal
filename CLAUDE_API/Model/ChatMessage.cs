using System.Collections.Generic;

namespace CLAUDE_API.Model
{
    public class ChatMessage
    {
        public string Role { get; set; }
        public string Content { get; set; }
    }

    public class ChatRequest
    {
        public List<ChatMessage> Messages { get; set; }
        public string SystemPrompt { get; set; }
        public double Temperature { get; set; } = 1.0;
        public string Prefill { get; set; }
        public List<string> StopSequences { get; set; }
    }
}