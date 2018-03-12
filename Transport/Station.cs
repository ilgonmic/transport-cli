using System.Collections.Generic;

namespace Transport
{
    class Station
    {
        public Station(string name)
        {
            this.Name = name;
        }
        
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var station = obj as Station;
            return station != null &&
                   Name == station.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
