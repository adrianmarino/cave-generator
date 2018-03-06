using Generator.Output;

namespace Generator.Step
{
    public interface IGenerationStep
    {
        IOutput Perform(StepContext ctx, object input);
    }
}