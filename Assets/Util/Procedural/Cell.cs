namespace Util.Procedural
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

        private ProceduralMap map;

        public Cell(ProceduralMap map, Point point)
        {
            this.point = point;
            this.map = map;
        }
    }
}