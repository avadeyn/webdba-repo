using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace system_SIS.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T? GetObject<T>(this ISession session, string key) where T : class
        {
            var value = session.GetString(key);
            return value == null ? null : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
