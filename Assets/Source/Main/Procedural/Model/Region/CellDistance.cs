using System;

namespace Procedural.Model {
    public class CellDistance: IComparable<CellDistance> {
        public int CompareTo(CellDistance other) {
            return value.CompareTo(other.value);
        }
        
        public Cell CellA { get; private set; }

        public Cell CellB { get; private set; }

        public float Value {
            get { 
                if(value < 0) value = CellA.Distance(CellB);
                return value;
            }
        }

        private float value = -1;

        public CellDistance(Cell cellA, Cell cellB) {
            CellA = cellA;
            CellB = cellB;
        }

    }
}
