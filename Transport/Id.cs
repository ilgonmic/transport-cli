namespace Transport
{
    class Id
    {
        public int id;

        public Id(int id)
        {
            this.id = id;
        }

        public override bool Equals(object obj)
        {
            var id = obj as Id;
            return id != null &&
                   this.id == id.id;
        }

        public override int GetHashCode()
        {
            return 1877310944 + id.GetHashCode();
        }
    }
}
