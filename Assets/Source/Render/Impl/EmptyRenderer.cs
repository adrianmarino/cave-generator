namespace Render
{
    public class EmptyRenderer: Renderer
    {        
        public override bool CanRender(RenderContext ctx)
        {
            return ctx.Data == null;
        }

        protected override void Update(RenderContext ctx)
        {
            CameraSettings.TwoDimnesion(ctx.Parent.Camera);
            ctx.Parent.CleanView();
        }
    }
}