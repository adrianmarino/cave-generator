namespace Procedural.Model
{
    public class Cell
    {
        public void MakeWall()
        {
            Value = WALL_VALUE;
        }
        
        public void MakeFloor()
        {
            Value = FLOOR_VALUE;
        }
        
        protected bool Equals(Cell other)
        {
            return Equals(coord, other.coord);
        }

        public override string ToString()
        {
            return string.Format("(X, Y, Value) = ({0}, {1}, {2})", Coord.X, Coord.Y, Value);
        }
        
        public int Value
        {
            get {
                return map.Value(coord);
            }
            set
            {
                map.Value(coord, value);
            }
        }

        public Coord Coord
        {
            get { return coord; }
        }

        public const int WALL_VALUE = 1;

        public const int FLOOR_VALUE = 0;

        private readonly Coord coord;

        private readonly CellMatrix map;

        public Cell(CellMatrix map, Coord coord)
        {
            this.coord = coord;
            this.map = map;
        }
    }
}