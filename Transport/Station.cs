using System.Collections.Generic;

namespace Transport
{
    class Station
    {
        public Station(Id id, string name)
        {
            Id = id;
            Name = name;
        }

        public Id Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var station = obj as Station;
            return station != null &&
                   EqualityComparer<Id>.Default.Equals(Id, station.Id) &&
                   Name == station.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = -1919740922;
            hashCode = hashCode * -1521134295 + EqualityComparer<Id>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
