using System.Text.Json;

namespace System
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        /// <summary> 
        /// 将对象序列为json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="serializerOptions"></param>
        /// <returns></returns>
        public static string ToJsonString<T>(this T obj, JsonSerializerOptions serializerOptions = null)
        {
            return serializerOptions == null
                ? JsonSerializer.Serialize(obj, DefaultJsonSerializerOptions)
                : JsonSerializer.Serialize(obj, serializerOptions);
        }

        /// <summary>
        /// 将json字符串反序列为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <param name="serializerOptions"></param>
        /// <returns></returns>
        public static T FromJsonString<T>(this string jsonString, JsonSerializerOptions serializerOptions = null)
        {
            return serializerOptions == null
                ? JsonSerializer.Deserialize<T>(jsonString, DefaultJsonSerializerOptions)
                : JsonSerializer.Deserialize<T>(jsonString, serializerOptions);
        }
    }
}