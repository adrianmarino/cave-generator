using UnityEngine;

namespace Procedural.Model {
    public class Cell {
        protected bool Equals(Cell other) {
            return Equals(coord, other.coord);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Cell) obj);
        }

        public override int GetHashCode() {
            return coord != null ? coord.GetHashCode() : 0;
        }

        public Vector3 ToWorld(Vector3 originCoords) {
            return Coord.ToWorld(originCoords);
        }

        public float Distance(Cell other) {
            return Coord.Distance(other.Coord);
        }

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
