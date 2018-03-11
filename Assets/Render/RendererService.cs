using System.Collections.Generic;
using System.Linq;
using Procedural.Generator.Output.Impl;

namespace Render
{
    public class RendererService
    {
        public void Render(RenderContext ctx)
        {
            var renderer = renderers.First(it => it.CanRender(ctx));
            if(renderer != null) renderer.Render(ctx);
        }

        readonly IList<IRenderer> renderers;

        public RendererService()
        {
            renderers = new List<IRenderer>
            {
                new EmptyRenderer(),
                new CellsRenderer(),
                new SquaresRenderer(),
                new MapMeshRenderer(),
                new WallsMeshRenderer()
            };
        }
    }

}