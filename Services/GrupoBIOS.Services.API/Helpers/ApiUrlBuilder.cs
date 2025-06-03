namespace GrupoBIOS.Services.API.Helpers
{
    public static class ApiUrlBuilder
    {
        public static string BuildUrl(string template, Dictionary<string, string> parameters)
        {
            string result = template;

            foreach (var param in parameters)
            {
                result = result.Replace($"{{{param.Key}}}", Uri.EscapeDataString(param.Value));
            }

            return result;
        }
    }
}
