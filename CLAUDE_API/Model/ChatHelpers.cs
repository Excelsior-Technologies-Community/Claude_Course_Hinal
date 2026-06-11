using System.Collections.Generic;

namespace CLAUDE_API.Model
{
    
    public static class ChatHelpers
    {
        public static void AddUserMessage(List<ChatMessage> messages, string text)
        {
            messages.Add(new ChatMessage { Role = "user", Content = text });
        }

        public static void AddAssistantMessage(List<ChatMessage> messages, string text)
        {
            messages.Add(new ChatMessage { Role = "assistant", Content = text });
        }

        public static string GetLastUserMessage(List<ChatMessage> messages)
        {
            if (messages == null) return null;

            for (int i = messages.Count - 1; i >= 0; i--)
            {
                if (messages[i].Role == "user")
                    return messages[i].Content;
            }

            return null;
        }
    }
}
