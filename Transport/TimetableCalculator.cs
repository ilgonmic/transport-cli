using System;
using System.Collections.Generic;

namespace Transport
{
    class TimetableCalculator
    {
        private readonly StationRegistry stationRegistry;

        public TimetableCalculator(List<Route> routes)
        {
            stationRegistry = new StationRegistry(routes);
        }

        public List<Timetable> GetTimetableForStation(DateTime time, string stationName)
        {
            Station station = stationRegistry.GetStationByName(stationName);
            List<Route> routes = stationRegistry.GetRoutesByStation(station);

            List<Timetable> result = new List<Timetable>();

            if (routes == null)
            {
                return null;
            }

            int intTime = TimeUtil.ToInt(time);
            foreach (var route in routes)
            {
                int pathElementIndex = route.FindPathElementIndex(station);
                PathElement pathElement = route.Path[pathElementIndex];

                var intTimeFromA = intTime;
                if (route.IsCorrectionRequiredFromA(pathElement) && intTime < route.GetFirstDepartureFromA(pathElement))
                {
                    intTimeFromA = TimeUtil.PlusOneDayToInt(time);
                }

                var intTimeFromZ = intTime;
                if (route.IsCorrectionRequiredFromZ(pathElement) && intTime < route.GetFirstDepartureFromZ(pathElement))
                {
                    intTimeFromZ = TimeUtil.PlusOneDayToInt(time);
                }

                var path = route.Path;
                int lastIndex = path.Count - 1;
                if (pathElementIndex != lastIndex)
                {
                    int waitingTime = CalculateWaitingMinutes(
                        intTimeFromA,
                        route.GetFirstDepartureFromA(pathElement),
                        route.GetLastDepartureFromA(pathElement),
                        route.Interval
                    );

                    result.Add(new Timetable(route.Number, path[lastIndex].Station, waitingTime));
                }

                int firstIndex = 0;
                if (pathElementIndex != firstIndex)
                {
                    int waitingTime = CalculateWaitingMinutes(
                        intTimeFromZ,
                        route.GetFirstDepartureFromZ(pathElement),
                        route.GetLastDepartureFromZ(pathElement),
                        route.Interval
                    );

                    result.Add(new Timetable(route.Number, path[firstIndex].Station, waitingTime));
                }
            }

            return result;
        }

        private int CalculateWaitingMinutes(int currentTime,
                                            int firstDeparture,
                                            int lastDeparture,
                                            int delay)
        {
            if ((firstDeparture < currentTime) && (currentTime < lastDeparture))
            {
                return (delay - (currentTime - firstDeparture) % delay) % delay;
            }

            int delta = firstDeparture - currentTime;

            if (delta < 0)
            {
                return 24 * 60 + delta;
            }

            return delta;
        }
    }
}
