using Procedural.Generator.Pipeline;
using UnityEngine;
using Procedural.Model;

namespace Render {
    public class MapMeshRenderer : Renderer {
        public override bool CanRender(RenderContext ctx) {
            return ctx.DataIs(typeof(IMesh[])) && ctx.Parent.Step == GenerationStep.Map;
        }

        protected override void Update(RenderContext ctx) {
            var meshes = (IMesh[]) ctx.Data;
            CameraSettings.TwoDimnesion(ctx.Parent.Camera);
            ctx.Parent.Camera.transform.position = new Vector3(-8.5f, 60f, 19f);
            ctx.Parent.Show(meshes);
        }
    }
}
