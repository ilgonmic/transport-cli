namespace Transport
{
    class Timetable
    {
        

        public Timetable(int routeNumber,
                         Station destination,
                         int waitintgTime)
        {
            RouteNumber = routeNumber;
            Destination = destination;
            WaitingTime = waitintgTime;
        }

        public int RouteNumber { get; set; }
        public Station Destination { get; set; }
        public int WaitingTime { get; set; }
    }
}
