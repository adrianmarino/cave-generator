namespace Util
{
    public class Cell
    {
        public int Value
        {
            get {
                return map.Value(point);
            }
            set
            {
                map.Value(point, value);
            }
        }

        public Point Point
        {
            get { return point; }
        }

        private Point point;

        private Map map;

        public Cell(Map map, Point point)
        {
            this.point = point;
            this.map = map;
        }
    }
}