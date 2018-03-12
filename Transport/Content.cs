using System.Collections.Generic;

namespace Transport
{
    class Content
    {
        public Content(List<Station> stations, List<Route> routes)
        {
            Stations = stations;
            Routes = routes;
        }

        public List<Station> Stations { get; set; }
        public List<Route> Routes { get; set; }
    }
}
