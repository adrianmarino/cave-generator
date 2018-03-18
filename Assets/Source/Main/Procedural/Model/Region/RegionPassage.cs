namespace Procedural.Model {
    public class RegionPassage {

        public float Distance {
            get { return CellA.Distance(CellB); }
        }

        public bool Contains(Region region1, Region region2) {
            return RegionA.Equals(region1) && RegionB.Equals(region2) ||
                   RegionB.Equals(region1) && RegionA.Equals(region2);
        }

        public Region RegionA { get; private set; }
        public Region RegionB { get; private set; }
        public Cell CellA { get; private set; }
        public Cell CellB { get; private set; }

        public RegionPassage(Region regionA, Region regionB, Cell cellA, Cell cellB) {
            RegionA = regionA;
            RegionB = regionB;
            CellA = cellA;
            CellB = cellB;
        }
    }
}
