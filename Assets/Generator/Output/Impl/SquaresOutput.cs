using UnityEngine;
using Util;
using Util.Procedural;

namespace Generator.Output.Impl
{
    public class SquaresOutput: Output<SquareMatrix>
    {
        public override void Render(MonoBehaviour behaviour)
        {
            data.ForEach(GizmosUtil.DrawSquare);
        }

        public SquaresOutput(SquareMatrix squares): base(squares)
        {
        }
    }
}