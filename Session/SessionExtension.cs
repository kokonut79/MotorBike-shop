using System.Text.Json;

namespace MotorbikeShop.Session
{
    public static class SessionExtension
    {
        public static void SetObject<T>(this ISession instance, string key, T value)
            where T : class
        {
            //Remove object from session if value given is null
            if (value == null)
            {
                instance.Remove(key);
                return;
            }

            //Else serialize to json and set the value to the session
            string jsonData = JsonSerializer.Serialize(value);
            instance.SetString(key, jsonData);
        }

        public static T GetObject<T>(this ISession instance, string key)
            where T : class
        {
            //if no keys return null
            if (!instance.Keys.Contains(key))
                return null;

            //take the data
            string jsonData = instance.GetString(key);

            //if empty return null
            if (String.IsNullOrEmpty(jsonData))
                return null;

            //else Deserialize and return the object
            return JsonSerializer.Deserialize<T>(jsonData);
        }
    }
}
