using System;
using System.Collections.Generic;
using System.IO;

namespace Transport
{
    class Program
    {
        static void Main(string[] args)
        {
            //Writer.Write();

            Content content;
            try
            {
                content = ContentReader.Read();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File {0} not found", e.FileName);
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to read data: {0}", e.Message);
                return;
            }

            TimetableCalculator timetableCalculator = new TimetableCalculator(content);

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter the station: ");
                string stationName = Console.ReadLine();

                if (stationName.Equals(""))
                {
                    return;
                }

                DateTime currentTime = DateTime.Now;
                List<Timetable> timetable = timetableCalculator.GetTimetableForStation(currentTime, stationName);

                if (timetable == null)
                {
                    Console.WriteLine("Station {0} does not exist", stationName);
                    continue;
                }

                timetable.Sort(delegate (Timetable first, Timetable second)
                {
                    return first.WaitingTime - second.WaitingTime;
                });

                Console.WriteLine("Current time: {0}", currentTime.ToString("HH:mm"));
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Shedule:");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var record in timetable)
                {
                    PrintRecord(record.RouteNumber, record.Destination.Name, record.WaitingTime);
                }
            }
        }

        private static void PrintRecord(int number,
            string terminalStationName,
            int waitingTime)
        {
            Console.Write("Route #{0} in destination to {1}: ", number, terminalStationName);

            if (waitingTime >= 60)
            {
                Console.WriteLine("{0} hour(s) {1} minute(s)", waitingTime / 60, waitingTime % 60);
                return;
            }
            Console.WriteLine("{0} minute(s)", waitingTime);
        }
    }
}
