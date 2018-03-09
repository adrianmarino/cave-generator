using Generator.Generator;
using Util;
using Util.Procedural;

namespace Generator.Output.Impl
{
    public class SquaresRenderer: Renderer
    {        
        public override bool CanRender(RenderContext ctx)
        {
            return ctx.DataIs(typeof(SquareMatrix));
        }

        protected override void OnDrawGizmos(RenderContext ctx)
        {
            initialize(ctx);
            var squareMatrix = (SquareMatrix) ctx.Data;
            squareMatrix.ForEach(GizmosUtil.DrawSquare);
        }

        private static void initialize(RenderContext ctx)
        {
            CameraSettings.TwoDimnesion(ctx.Parent.Camera);
        }
    }
}