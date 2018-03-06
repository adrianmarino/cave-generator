using Generator.Output;
using Generator.Output.Impl;
using Util;
using Util.Procedural;

namespace Generator.Step.Impl
{
    public class CellGenerationStep: IGenerationStep
    {
        public IOutput Perform(StepContext ctx, object input)
        {
            var random = RandomFactory.Create();

            var cells = new CellMatrix(ctx.Width, ctx.Height)
                .Fill(random, ctx.RandomFillPercent)
                .Smooth(ctx.SmoothSteps, ctx.MaxActiveNeighbors, ctx.NeighboursRadio);

            return new CellsOutput(cells);
        }
    }
}