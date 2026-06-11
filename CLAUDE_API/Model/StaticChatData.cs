using System.Collections.Generic;

namespace CLAUDE_API.Model
{
    
    public static class StaticChatData
    {
        public const string Model = "claude-3-7-sonnet-20250219";
        public const int MaxTokens = 1000;

        public const string PythonEngineerSystemPrompt =
            "You are a Python engineer who writes very concise code";

        public const string DuplicateCharsPrompt =
            "Write a Python function that checks a string for duplicate characters.";

        public const string DuplicateCharsResponse =
            "def has_duplicates(s):\n    return len(s) != len(set(s))";

        public const string MovieIdeaPrompt = "Generate a one sentence movie idea";

        public const string MovieIdeaDeterministic =
            "A retired spy discovers his implanted memories may be the only thing keeping a hidden city alive.";

        public static readonly string[] MovieIdeasCreative = new[]
        {
            "A librarian finds that every book returned late rewrites one day of her past.",
            "Two rival chefs inherit a restaurant that only opens during solar eclipses.",
            "A delivery drone develops opinions and starts rating its customers.",
            "An underwater welder hears music coming from a sunken subway car.",
            "A time-traveling barista keeps accidentally changing history with latte art."
        };

        public const string EventBridgePrompt = "Generate a very short event bridge rule as json";

        public const string EventBridgeJson =
            "{\n  \"source\": [\"aws.ec2\"],\n  \"detail-type\": [\"EC2 Instance State-change Notification\"],\n  \"detail\": {\n    \"state\": [\"running\"]\n  }\n}";

        public const string AwsCliPrompt =
            "Generate three different sample AWS CLI commands. Each should be very short.";

        public const string AwsCliPrefill =
            "Here are all three commands in a single block without any comments:\n```bash";

        public const string AwsCliResponse =
            "bash\naws s3 ls\naws ec2 describe-instances\naws lambda list-functions";

        public const string FakeDatabasePrompt =
            "Write a 1 sentence description of a fake database";

        public const string FakeDatabaseResponse =
            "PetVaultDB is a distributed document store that indexes every record by pet species and ranks query results by estimated tail-wag velocity.";

        public static readonly Dictionary<string, string> BasicResponses = new Dictionary<string, string>
        {
            { "hello", "Hello! I'm a static demo assistant. Ask me anything and I'll reply from canned data." },
            { "hi", "Hi there! This chat uses static responses — no Claude API is called." },
            { "how are you", "I'm running entirely on static data in this MVC 5 demo. Ready when you are!" }
        };

        public const string BasicDefaultResponse =
            "Thanks for your message. This is a static reply from the Basic Chat demo (Task 1). " +
            "In the Python notebook, this would call client.messages.create with your conversation history.";
    }
}
