using Newtonsoft.Json;

namespace UnityEngine.AddressableAssets.Utility
{
    public class JsonUtility
    {
        public static object FromJson(string json, Type type)
        {
            object result;
            if (string.IsNullOrEmpty(json))
            {
                result = null;
            }
            else
            {
                if (type == null)
                {
                    throw new ArgumentNullException("type");
                }
                if (type.IsAbstract || type.IsSubclassOf(typeof(object)))
                {
                    throw new ArgumentException("Cannot deserialize JSON to new instances of type '" + type.Name + ".'");
                }
                result = JsonConvert.DeserializeObject(json, type);
            }
            return result;
        }

        public static string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
