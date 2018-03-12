using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Transport
{
    class RoutesReader
    {
        public static List<Route> Read()
        {
            string json = ReadFromFile();

            return JsonConvert.DeserializeObject<List<Route>>(json);
        }

        private static string ReadFromFile()
        {
            StreamReader reader = new StreamReader("../../hw1.txt");
            string json = reader.ReadLine();
            return json;
        }
    }
}
