using UnityEngine;
using Util;
using Util.Procedural;

namespace Generator.Output.Impl
{
    public class CellsOutput : Output<CellMatrix>
    {
        public override void Render(MonoBehaviour behaviour)
        {
            data.ForEach(cell => GizmosUtil.DrawCell(data, cell));
        }

        public CellsOutput(CellMatrix cells) : base(cells)
        {
        }
    }
}