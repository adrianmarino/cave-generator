namespace Procedural.Model
{
    public class Point
    {
        private bool Equals(Point other)
        {
            return x == other.x && y == other.y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Point) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (x * 397) ^ y;
            }
        }

        public override string ToString()
        {
            return string.Format("(x: {0}, y: {1})", X, Y);
        }

        public int X
        {
            get { return x; }
        }
        
        public int Y
        {
            get { return y;  }
        }
        
        private readonly int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}