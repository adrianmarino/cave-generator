namespace Render.Impl {
    public class NullRenderer : IRenderer {
        public void Render(RenderContext ctx) { }

        public bool CanRender(RenderContext context) {
            return true;
        }
    }
}
