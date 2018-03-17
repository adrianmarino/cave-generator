using Procedural.Generator.Pipeline;
using UnityEngine;
using Procedural.Model;
using Util;

namespace Render {
    public class WallsMeshRenderer : Renderer {
        public override bool CanRender(RenderContext ctx) {
            return ctx.DataIs(typeof(IMesh[])) && ctx.Parent.Step == GenerationStep.Walls;
        }

        protected override void Update(RenderContext ctx) {
            var meshes = (IMesh[]) ctx.Data;
            CameraSettings.ThreeDimnesion(ctx.Parent.Camera);
            ctx.Parent.MeshFilters.ForEach(it => it.transform.position = new Vector3(0, 5, 0.5f));
            ctx.Parent.Show(meshes);
        }
    }
}