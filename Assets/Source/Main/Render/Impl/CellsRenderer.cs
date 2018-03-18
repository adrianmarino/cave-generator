using Util;
using Procedural.Model;
using Gizmos = Procedural.Model.GizmosUtil;

namespace Render {
    public class CellsRenderer : Renderer {
        public override bool CanRender(RenderContext ctx) {
            return ctx.DataIs(typeof(CellMatrix));
        }

        protected override void OnDrawGizmos(RenderContext ctx) {
            Initialize(ctx);
            var cellMatrix = (CellMatrix) ctx.Data;

            cellMatrix.ForEach(cell => Gizmos.DrawCell(cellMatrix.BottomLeft, cell));
            cellMatrix.Passages.ForEach(passage => Gizmos.DrawPassage(cellMatrix.BottomLeft, passage));

        }

        private static void Initialize(RenderContext ctx) {
            CameraSettings.TwoDimnesion(ctx.Parent.Camera);
        }
    }
}
