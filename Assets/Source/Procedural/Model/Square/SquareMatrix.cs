using System.Collections;
using System.Collections.Generic;

namespace Procedural.Model
{
    public class SquareMatrix: IEnumerable<Square>
    {       
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Square> GetEnumerator()
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    yield return squares[x, y];
                }
            }
        }

        public float Width
        {
            get { return squares.GetLength(0); }
        }

        public float Height
        {
            get { return squares.GetLength(1);  }
        }

        private static Square CreateSquare(SquareEdgeNodeMatrix edgeNodes, int x, int y)
        {
            return new Square(
                edgeNodes[x, y+1],
                edgeNodes[x+1, y+1],
                edgeNodes[x, y],
                edgeNodes[x+1, y]
            );
        }
        
        readonly Square[,] squares;

        public SquareMatrix(SquareEdgeNodeMatrix edgeNodes)
        {
            squares = new Square[edgeNodes.Width - 1, edgeNodes.Height - 1];

            for (var x = 0; x < edgeNodes.Width - 1; x++)
            {
                for (var y = 0; y < edgeNodes.Height - 1; y++)
                {
                    squares[x, y] = CreateSquare(edgeNodes, x, y);
                }
            }
        }
    }
}