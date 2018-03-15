namespace Procedural.Model {
    public class Cell {
        public static int IntValue(Cell cell) {
            return (int) cell.Value;
        }

        public bool isWall() {
            return Value == CellValue.Wall;
        }

        public void MakeWall() {
            Value = CellValue.Wall;
        }

        public void MakeFloor() {
            Value = CellValue.Floor;
        }

        protected bool Equals(Cell other) {
            return Equals(coord, other.coord);
        }

        public override string ToString() {
            return string.Format("(X, Y, Value) = ({0}, {1}, {2})", Coord.X, Coord.Y, Value);
        }

        public CellValue Value {
            get { return map.Value(coord); }
            set { map.Value(coord, value); }
        }

        public Coord Coord {
            get { return coord; }
        }

        private readonly Coord coord;

        private readonly CellMatrix map;

        public Cell(CellMatrix map, Coord coord) {
            this.coord = coord;
            this.map = map;
        }
    }
}
