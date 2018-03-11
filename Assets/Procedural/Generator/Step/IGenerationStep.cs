namespace Procedural.Generator.Step
{
    public interface IGenerationStep
    {
        object Perform(StepContext ctx, object input);
    }
}