using Util;
using Procedural.Model;

namespace Procedural.Generator.Step.Impl
{
    public class CellsGenerationStep: IGenerationStep
    {
        public object Perform(StepContext ctx, object input)
        {
            var random = RandomFactory.Create();

            return new CellMatrix(ctx.Width, ctx.Height)
                .Fill(random, ctx.RandomFillPercent)
                .Smooth(ctx.SmoothSteps, ctx.MaxActiveNeighbors, ctx.NeighboursRadio);
        }
    }
}