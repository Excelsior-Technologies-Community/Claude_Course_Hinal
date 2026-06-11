using System;
using System.Collections.Generic;

namespace CLAUDE_API.Model
{
    public class ToolsService
    {
        public string GetWeatherToolResponse(string location)
        {
            return $"{{\n  \"tool_use\": {{\n    \"name\": \"get_weather\",\n    \"input\": {{\n      \"location\": \"{location}\"\n    }}\n  }}\n}}";
        }

        public string GetWebSearchResponse(string query)
        {
            return $"{{\n  \"tool_use\": {{\n    \"name\": \"web_search\",\n    \"input\": {{\n      \"query\": \"{query}\"\n    }}\n  }}\n}}";
        }
    }
}
