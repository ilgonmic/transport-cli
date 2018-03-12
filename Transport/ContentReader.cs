using Newtonsoft.Json;
using System.IO;

namespace Transport
{
    class ContentReader
    {
        public static Content Read()
        {
            string json = ReadFromFile();

            return JsonConvert.DeserializeObject<Content>(json);
        }

        private static string ReadFromFile()
        {
            StreamReader reader = new StreamReader("../../hw1.txt");
            string json = reader.ReadLine();
            return json;
        }
    }
}
