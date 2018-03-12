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
            Station school = new Station(new Id(1), "School");
            Station otradnoye = new Station(new Id(2), "Otradnoye");
            Station polyclinic = new Station(new Id(3), "Polyclinic");
            Station polarnaya = new Station(new Id(4), "Polarnaya");
            Station goncharova = new Station(new Id(5), "Goncharova");
            Station sovetskaya = new Station(new Id(6), "Sovetskaya");
            Station mira = new Station(new Id(7), "Mira");
            Station babushkinskaya = new Station(new Id(8), "Babushkinskaya");
            Station hospital = new Station(new Id(9), "Hospital");
            Station nauchnaya = new Station(new Id(10), "Nauchnaya");
            Station yasnaya = new Station(new Id(11), "Yasnaya");
            Station severnaya = new Station(new Id(12), "Severnaya");
            Station tverskaya = new Station(new Id(13), "Tverskaya");
            Station dekabristov = new Station(new Id(14), "Dekabristov");
            Station sviblovo = new Station(new Id(15), "Sviblovo");
            Station sadovaya = new Station(new Id(16), "Sadovaya");
            Station pervomayskaya = new Station(new Id(17), "Pervomayskaya");
            Station institutskaya = new Station(new Id(18), "Institutskaya");
            Station kirpichnaya = new Station(new Id(19), "Kirpichnaya");
            Station vdnkh = new Station(new Id(20), "VDNKh");


            string json = JsonConvert.SerializeObject(
                new Content(
                    new List<Station>()
                    {
                        school,
                        otradnoye,
                        polyclinic,
                        polarnaya,
                        goncharova,
                        sovetskaya,
                        mira,
                        babushkinskaya,
                        hospital,
                        nauchnaya,
                        yasnaya,
                        severnaya,
                        tverskaya,
                        dekabristov,
                        sviblovo,
                        sadovaya,
                        pervomayskaya,
                        institutskaya,
                        kirpichnaya,
                        vdnkh
                    },
                    new List<Route>()
                    {
                        new Route(
                            696,
                            new List<PathElement>
                            {
                                new PathElement(school.Id, 0),
                                new PathElement(otradnoye.Id, 5),
                                new PathElement(polyclinic.Id, 6),
                                new PathElement(polarnaya.Id, 4),
                                new PathElement(goncharova.Id, 5)
                            },
                            new DateTime().AddHours(5).AddMinutes(30),
                            new DateTime().AddHours(23).AddMinutes(30),
                            20
                        ),
                        new Route(
                            605,
                            new List<PathElement>
                            {
                                new PathElement(otradnoye.Id, 0),
                                new PathElement(yasnaya.Id, 8),
                                new PathElement(severnaya.Id, 3),
                                new PathElement(babushkinskaya.Id, 6),
                                new PathElement(tverskaya.Id, 5),
                                new PathElement(dekabristov.Id, 7)
                            },
                            new DateTime().AddHours(6).AddMinutes(30),
                            new DateTime().AddHours(01).AddMinutes(10),
                            10
                        ),
                        new Route(
                            71,
                            new List<PathElement>
                            {
                                new PathElement(sovetskaya.Id, 0),
                                new PathElement(polarnaya.Id, 6),
                                new PathElement(mira.Id, 3),
                                new PathElement(babushkinskaya.Id, 5),
                                new PathElement(hospital.Id, 4),
                                new PathElement(nauchnaya.Id, 5)
                            },
                            new DateTime().AddHours(7).AddMinutes(5),
                            new DateTime().AddHours(23).AddMinutes(55),
                            5
                        ),
                        new Route(
                            124,
                            new List<PathElement>
                            {
                                new PathElement(sviblovo.Id, 0),
                                new PathElement(babushkinskaya.Id, 3),
                                new PathElement(sadovaya.Id, 2),
                                new PathElement(pervomayskaya.Id, 5),
                                new PathElement(institutskaya.Id, 3),
                                new PathElement(nauchnaya.Id, 4),
                                new PathElement(kirpichnaya.Id, 6)
                            },
                            new DateTime().AddHours(12).AddMinutes(0),
                            new DateTime().AddHours(3).AddMinutes(0),
                            30
                        )
                    }
                ),
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
