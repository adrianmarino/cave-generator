namespace Util.Procedural
{
    public static class SquareMatrixFactory
    {
        public static SquareMatrix Create(CellMatrix cellMatrix, float squadSide)
        {
            var edgeNodes = new SquareEdgeNodeMatrix(cellMatrix, squadSide);
            return new SquareMatrix(edgeNodes);
        }
    }
}