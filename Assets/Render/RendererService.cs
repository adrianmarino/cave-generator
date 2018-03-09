using System.Collections.Generic;
using System.Linq;
using Generator.Output.Impl;

namespace Generator.Generator
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
                new MeshRenderer()
            };
        }
    }

}