using System.IO;
using System.Web;
using Newtonsoft.Json;

namespace CLAUDE_API.Model
{
    public static class RequestHelper
    {
        public static T ReadJsonBody<T>() where T : new()
        {
            var request = HttpContext.Current?.Request;
            if (request == null)
                return new T();

            request.InputStream.Position = 0;
            using (var reader = new StreamReader(request.InputStream))
            {
                var json = reader.ReadToEnd();
                if (string.IsNullOrWhiteSpace(json))
                    return new T();

                var result = JsonConvert.DeserializeObject<T>(json);
                return result == null ? new T() : result;
            }
        }
    }
}
