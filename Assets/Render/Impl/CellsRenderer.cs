using Generator.Generator;
using UnityEngine;
using Util;
using Util.Procedural;

namespace Generator.Output.Impl
{
    public class CellsRenderer : IRenderer
    {
        public void Render(MonoBehaviour behaviour, object data)
        {
            var cellMatrix = (CellMatrix) data;
            cellMatrix.ForEach(cell => GizmosUtil.DrawCell(cellMatrix, cell));
        }

        public bool CanRender(object data)
        {
            return typeof(CellMatrix) == data.GetType();
        }
    }
}