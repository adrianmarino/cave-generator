using System;

namespace Render
{
    public abstract class Renderer : IRenderer
    {        
        public abstract bool CanRender(RenderContext context);

        public void Render(RenderContext ctx)
        {
            switch (ctx.Event)
            {
                case RenderEvent.OnDrawGizmos:
                    OnDrawGizmos(ctx);
                    break;
                case RenderEvent.Update:
                    Update(ctx);
                    break;
                default:
                    throw new NotImplementedException("Unsupported event!");
            }
        }

        protected virtual void OnDrawGizmos(RenderContext context)
        {
        }

        protected virtual void Update(RenderContext context)
        {
        }
    }
}