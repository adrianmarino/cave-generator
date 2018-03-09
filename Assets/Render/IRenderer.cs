namespace Generator.Generator
{
    public interface IRenderer
    {
        void Render(RenderContext ctx);

        bool CanRender(RenderContext context);
    }
}