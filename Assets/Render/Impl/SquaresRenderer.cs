using Generator.Generator;
using UnityEngine;
using Util;
using Util.Procedural;

namespace Generator.Output.Impl
{
    public class SquaresRenderer: IRenderer
    {
        public void Render(MonoBehaviour behaviour, object data)
        {
            var squareMatrix = (SquareMatrix) data;
            squareMatrix.ForEach(GizmosUtil.DrawSquare);
        }

        public bool CanRender(object data)
        {
            return typeof(SquareMatrix) == data.GetType();
        }
    }
}