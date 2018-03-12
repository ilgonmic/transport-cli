using System;
using System.Collections.Generic;

namespace Transport
{
    class Route
    {
        private bool isInited;

        public Route(int number,
            List<PathElement> path,
            DateTime firstDeparture,
            DateTime lastDeparture,
            int interval)
        {
            isInited = false;
            Number = number;
            Path = path;

            FirstDeparture = firstDeparture;
            LastDeparture = lastDeparture;

            Interval = interval;
        }

        public int Number { get; set; }
        public List<PathElement> Path { get; set; }

        public DateTime FirstDeparture { get; set; }
        public DateTime LastDeparture { get; set; }

        public int Interval { get; set; }

        private int FullInterval { get; set; }

        public int FindPathElementIndex(Id id)
        {
            Init();

            return Path.FindIndex(delegate (PathElement pathElement)
            {
                return pathElement.Id.Equals(id);
            });
        }

        public int GetFirstDepartureFromA(PathElement pathElement)
        {
            Init();
            return TimeUtil.ToInt(FirstDeparture.AddMinutes(pathElement.DistanceFromA));
        }

        public int GetLastDepartureFromA(PathElement pathElement)
        {
            Init();
            DateTime lastDeparture = LastDeparture.AddMinutes(pathElement.DistanceFromA);

            if (IsCorrectionRequiredFromA(pathElement))
            {
                return TimeUtil.PlusOneDayToInt(lastDeparture);
            }

            return TimeUtil.ToInt(lastDeparture);
        }

        public int GetFirstDepartureFromZ(PathElement pathElement)
        {
            Init();
            return TimeUtil.ToInt(FirstDeparture.AddMinutes(FullInterval - pathElement.DistanceFromA));
        }

        public int GetLastDepartureFromZ(PathElement pathElement)
        {
            Init();
            DateTime lastDeparture = LastDeparture.AddMinutes(FullInterval - pathElement.DistanceFromA);

            if (IsCorrectionRequiredFromZ(pathElement))
            {
                return TimeUtil.PlusOneDayToInt(lastDeparture);
            }

            return TimeUtil.ToInt(lastDeparture);
        }

        public bool IsCorrectionRequiredFromA(PathElement pathElement)
        {
            Init();
            int lastTimeInCurrentDay = TimeUtil.ToInt(LastDeparture.AddMinutes(pathElement.DistanceFromA));
            return lastTimeInCurrentDay < GetFirstDepartureFromZ(pathElement);
        }

        public bool IsCorrectionRequiredFromZ(PathElement pathElement)
        {
            Init();
            int lastTimeInCurrentDay = TimeUtil.ToInt(LastDeparture.AddMinutes(FullInterval - pathElement.DistanceFromA));
            return lastTimeInCurrentDay < GetFirstDepartureFromZ(pathElement);
        }

        private void Init()
        {
            if (isInited)
            {
                return;
            }

            isInited = true;

            Path[0].DistanceFromA = 0;

            for (int i = 1; i < Path.Count; i++)
            {
                PathElement directPathElement = Path[i];
                int directInterval = directPathElement.Distance;
                FullInterval = FullInterval + directInterval;

                directPathElement.DistanceFromA = Path[i - 1].DistanceFromA + directInterval;
            }
        }
    }

    class PathElement
    {
        public PathElement(Id id, int distance)
        {
            Id = id;
            Distance = distance;
        }

        public Id Id { get; set; }
        public int Distance { get; set; }

        internal int DistanceFromA { get; set; }
    }
}
