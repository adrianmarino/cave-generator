using Generator.Generator;
using UnityEngine;
using Util;
using Util.Procedural;
using Renderer = Generator.Generator.Renderer;

namespace Generator.Output.Impl
{
    public class MeshRenderer: Renderer
    {        
        public override bool CanRender(RenderContext ctx)
        {
            return ctx.DataIs(typeof(IMesh[]));
        }

        protected override void Update(RenderContext ctx)
        {
            Initialize(ctx);
            var meshes = GetInput(ctx);

            for (var index = 0; index < meshes.Length; index++)
            {
                var mesh = meshes[index];
                var filter = ctx.Parent.MeshFilters[index];
                
                // Debug.LogFormat("Render {0} to {1} filter", mesh.GetType(), filter);

                filter.mesh = mesh.asUnityMesh();
            }
        }

        private static void Initialize(RenderContext ctx)
        {
            CameraSettings.ThreeDimnesion(ctx.Parent.Camera);
            ctx.Parent.MeshFilters.ForEach(it => it.transform.position = new Vector3(0, 5, 0.5f));
        }

        private static IMesh[] GetInput(RenderContext ctx)
        {
            return (IMesh[]) ctx.Data;
        }
    }
}