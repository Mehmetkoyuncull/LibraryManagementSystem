using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DataAccess
{
    public static class FileHelper<T>
    {
        public static void SaveToFile(List<T> data, string filePath)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static List<T> LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<T>();

            string json = File.ReadAllText(filePath);

            try
            {
                return JsonConvert.DeserializeObject<List<T>>(json, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }) ?? new List<T>();
            }
            catch
            {
                // JSON hatalıysa boş liste döner
                return new List<T>();
            }
        }
    }
}
