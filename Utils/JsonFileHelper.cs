using Newtonsoft.Json;

namespace blog_management_service.Utils
{
    /// <summary>
    /// Helper class for reading and writing JSON files.
    /// </summary>
    public static class JsonFileHelper
    {
        private static readonly string JsonFilePath = Path.Join(Directory.GetCurrentDirectory(), "./Data/Mock/posts.json");

        /// <summary>
        /// Checks if the JSON file exists and creates it if it doesn't.
        /// </summary>
        public static void CheckAndCreate()
        {
            if (!File.Exists(JsonFilePath))
            {
                Directory.CreateDirectory(Path.Join(Directory.GetCurrentDirectory(), "./Data/Mock"));
                File.Create(JsonFilePath).Close();
            }
        }

        /// <summary>
        /// Reads data from a JSON file and deserializes it into a list of objects.
        /// </summary>
        /// <typeparam name="T">The type of objects to deserialize.</typeparam>
        /// <returns>A list of deserialized objects.</returns>
        public static List<T> ReadFromJsonFile<T>()
        {
            using StreamReader file = File.OpenText(JsonFilePath);
            JsonSerializer serializer = new JsonSerializer();
            return (List<T>)serializer.Deserialize(file, typeof(List<T>));
        }

        /// <summary>
        /// Serializes a list of objects and writes it to a JSON file.
        /// </summary>
        /// <typeparam name="T">The type of objects to serialize.</typeparam>
        /// <param name="data">The list of objects to serialize.</param>
        public static void WriteToJsonFile<T>(List<T> data)
        {
            using StreamWriter file = File.CreateText(JsonFilePath);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, data);
        }
    }
}
