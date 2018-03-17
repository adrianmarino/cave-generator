using Util;
using Procedural.Model;
using UnityEngine;

namespace Render {
    public class CellsRenderer : Renderer {
        public override bool CanRender(RenderContext ctx) {
            return ctx.DataIs(typeof(CellMatrix));
        }

        protected override void OnDrawGizmos(RenderContext ctx) {
            Initialize(ctx);
            var cellMatrix = (CellMatrix) ctx.Data;

            cellMatrix.ForEach(cell => GizmosUtil.DrawCell(cellMatrix, cell));
            cellMatrix.Passages.ForEach(passage => GizmosUtil.DrawPassage(cellMatrix, passage));
        }

        private static void Initialize(RenderContext ctx) {
            CameraSettings.TwoDimnesion(ctx.Parent.Camera);
        }
    }
}
