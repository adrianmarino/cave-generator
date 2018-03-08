using System.Collections.Generic;
using System.Linq;
using Generator.Output.Impl;

namespace Generator.Generator
{
    public class RendererResolver
    {
        public IRenderer resolve(object data)
        {
            return renderers.First(it => it.CanRender(data));
        }

        readonly IList<IRenderer> renderers;

        public RendererResolver()
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