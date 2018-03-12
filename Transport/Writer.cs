using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;

namespace Transport
{
    class Writer
    {
        public static void Write()
        {
            Station school = new Station("School");
            Station otradnoye = new Station("Otradnoye");
            Station polyclinic = new Station("Polyclinic");
            Station polarnaya = new Station("Polarnaya");
            Station goncharova = new Station("Goncharova");
            Station sovetskaya = new Station("Sovetskaya");
            Station mira = new Station("Mira");
            Station babushkinskaya = new Station("Babushkinskaya");
            Station hospital = new Station("Hospital");
            Station nauchnaya = new Station("Nauchnaya");
            Station yasnaya = new Station("Yasnaya");
            Station severnaya = new Station("Severnaya");
            Station tverskaya = new Station("Tverskaya");
            Station dekabristov = new Station("Dekabristov");
            Station sviblovo = new Station("Sviblovo");
            Station sadovaya = new Station("Sadovaya");
            Station pervomayskaya = new Station("Pervomayskaya");
            Station institutskaya = new Station("Institutskaya");
            Station kirpichnaya = new Station("Kirpichnaya");


            string json = JsonConvert.SerializeObject(
                new List<Route>()
                {
                    new Route(
                        696,
                        new List<PathElement>
                        {
                            new PathElement(school, 0),
                            new PathElement(otradnoye, 5),
                            new PathElement(polyclinic, 6),
                            new PathElement(polarnaya, 4),
                            new PathElement(goncharova, 5)
                        },
                        new DateTime().AddHours(5).AddMinutes(30),
                        new DateTime().AddHours(23).AddMinutes(30),
                        20
                    ),
                    new Route(
                        605,
                        new List<PathElement>
                        {
                            new PathElement(otradnoye, 0),
                            new PathElement(yasnaya, 8),
                            new PathElement(severnaya, 3),
                            new PathElement(babushkinskaya, 6),
                            new PathElement(tverskaya, 5),
                            new PathElement(dekabristov, 7)
                        },
                        new DateTime().AddHours(6).AddMinutes(30),
                        new DateTime().AddHours(01).AddMinutes(10),
                        10
                    ),
                    new Route(
                        71,
                        new List<PathElement>
                        {
                            new PathElement(sovetskaya, 0),
                            new PathElement(polarnaya, 6),
                            new PathElement(mira, 3),
                            new PathElement(babushkinskaya, 5),
                            new PathElement(hospital, 4),
                            new PathElement(nauchnaya, 5)
                        },
                        new DateTime().AddHours(7).AddMinutes(5),
                        new DateTime().AddHours(23).AddMinutes(55),
                        5
                    ),
                    new Route(
                        124,
                        new List<PathElement>
                        {
                            new PathElement(sviblovo, 0),
                            new PathElement(babushkinskaya, 3),
                            new PathElement(sadovaya, 2),
                            new PathElement(pervomayskaya, 5),
                            new PathElement(institutskaya, 3),
                            new PathElement(nauchnaya, 4),
                            new PathElement(kirpichnaya, 6)
                        },
                        new DateTime().AddHours(12).AddMinutes(0),
                        new DateTime().AddHours(3).AddMinutes(0),
                        30
                    )


                },
                new IsoDateTimeConverter() { DateTimeFormat = "HH:mm" }
            );

            WriteToFile(json);
        }

        private static void WriteToFile(string json)
        {
            FileStream file = new FileStream("../../hw1.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(file);
            writer.Write(json);
            writer.Close();
        }
    }
}
