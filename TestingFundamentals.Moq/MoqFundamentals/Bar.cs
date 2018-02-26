using System;

namespace TestingFundamentals.Moq.MoqFundamentals
{
    public class Bar : IEquatable<Bar>
    {
        public bool Equals(Bar other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Bar) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public static bool operator ==(Bar left, Bar right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Bar left, Bar right)
        {
            return !Equals(left, right);
        }

        public string Name { get; set; }
    }
}