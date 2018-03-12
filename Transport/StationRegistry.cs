using System.Collections.Generic;

namespace Transport
{
    class StationRegistry
    {
        private readonly Dictionary<Station, List<Route>> stationToRoutes;

        public StationRegistry(List<Route> routes)
        {
            stationToRoutes = new Dictionary<Station, List<Route>>();
            foreach (var route in routes)
            {
                foreach (var pathElement in route.Path)
                {
                    if (stationToRoutes.TryGetValue(pathElement.Station, out List<Route> stationRoute))
                    {
                        stationRoute.Add(route);
                    }
                    else
                    {
                        stationToRoutes.Add(pathElement.Station, new List<Route>() { route });
                    }
                }
            }
        }

        public Station GetStationByName(string name)
        {
            return new Station(name);
        }

        public List<Route> GetRoutesByStation(Station station)
        {
            List<Route> result = new List<Route>();
            if (stationToRoutes.TryGetValue(station, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
