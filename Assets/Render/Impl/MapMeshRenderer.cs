using Generator.Generator;
using Generator.Step;
using UnityEngine;
using Util;
using Util.Procedural;
using Renderer = Generator.Generator.Renderer;

namespace Generator.Output.Impl
{
    public class MapMeshRenderer: Renderer
    {
        public override bool CanRender(RenderContext ctx)
        {
            return ctx.DataIs(typeof(IMesh[])) && ctx.Parent.Step == GenerationStep.Map;
        }

        protected override void Update(RenderContext ctx)
        {
            var meshes = (IMesh[]) ctx.Data;
            CameraSettings.TwoDimnesion(ctx.Parent.Camera);
            ctx.Parent.Camera.transform.position = new Vector3(-8.5f, 60f, 19f);
            ctx.Parent.Show(meshes);
        }
    }
}