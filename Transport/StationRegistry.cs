using System.Collections.Generic;

namespace Transport
{
    class StationRegistry
    {
        private readonly List<Station> stations;
        private readonly Dictionary<Id, List<Route>> stationToRoutes;

        public StationRegistry(Content content)
        {
            stations = content.Stations;
            stationToRoutes = new Dictionary<Id, List<Route>>();
            foreach (var route in content.Routes)
            {
                foreach (var pathElement in route.Path)
                {
                    if (stationToRoutes.TryGetValue(pathElement.Id, out List<Route> stationRoute))
                    {
                        stationRoute.Add(route);
                    }
                    else
                    {
                        stationToRoutes.Add(pathElement.Id, new List<Route>() { route });
                    }
                }
            }
        }

        public Station GetStationById(Id id)
        {
            return stations.Find(station => station.Id.Equals(id));
        }

        public Station GetStationByName(string name)
        {
            return stations.Find(station => station.Name.Equals(name));
        }

        public List<Route> GetRoutesByStationId(Id stationId)
        {
            List<Route> result = new List<Route>();
            if (stationToRoutes.TryGetValue(stationId, out result))
            {
                return result;
            }
            else
            {
                return new List<Route>();
            }
        }
    }
}
