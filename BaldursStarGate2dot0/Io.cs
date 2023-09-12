using System.Text.Json;
using System.Xml.Serialization;


namespace BaldursStarGate2dot0
{
    internal class Io
    {
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public static void Save<T>(T obj)
        {
            string json = JsonSerializer.Serialize(obj);
            //TODO Try catch
            using (StreamWriter writer = new(Path.Combine(path, $"{obj.GetType()}.json")))
            {
                writer.WriteLine(json);
            };
        }

        public static T? Load<T>()
        {
            string file = Path.Combine(path, $"{typeof(T)}.json");
            //Prevention before exception
            if (!File.Exists(file)) return default(T);
            
            //TODO Trycatch
            string json;
            using (StreamReader reader = new StreamReader(file))
            {
                json = reader.ReadToEnd();
            };
            T? obj = JsonSerializer.Deserialize<T>(json);
            return obj;
        }

        //Just an example of doing the XML way instead of JSON
        public static void SaveGameXML(Player player)
        {
            TextWriter writer = new StreamWriter(Path.Combine(path, "savegame.json"));
            new XmlSerializer(typeof(Player)).Serialize(writer, player);
        }
        //public static Player? Load()
        //{
        //    //Prevention before exception
        //    if (!File.Exists(Path.Combine(path, "savegame.json"))) return null;

        //    //TODO Trycatch
        //    string json;
        //    using (StreamReader reader = new StreamReader(Path.Combine(path, "savegame.json")))
        //    {
        //        json = reader.ReadToEnd();
        //    };
        //    Player? player = JsonSerializer.Deserialize<Player>(json);
        //    return player;
        //}
    }
}
