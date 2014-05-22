using System;

namespace ConsoleApplication3.Entities
{
    public class OdeskJobItem
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string PublishDate { get; set; }

        protected bool Equals(OdeskJobItem other)
        {
            return string.Equals(Title, other.Title) && string.Equals(Link, other.Link);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Title != null ? Title.GetHashCode() : 0)*397) ^ (Link != null ? Link.GetHashCode() : 0);
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OdeskJobItem) obj);
        }
    }
}
