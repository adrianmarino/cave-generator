using Util;
using Procedural.Model;

namespace Procedural.Generator.Step.Impl
{
    public class CellsGenerationStep: IGenerationStep
    {
        public object Perform(StepContext ctx, object input)
        {
            return CreateCellMatrix(ctx)
                .Fill(CreateFillStrategy(ctx))
                .Smooth(
                    ctx.SmoothSteps,
                    ctx.MaxActiveNeighbors,
                    ctx.NeighboursRadio
                )
                .RemoveRegions(ctx.RemoveRegionsSize)
                .MakeBorders();
        }

        private static RandomFillPercentStrategy CreateFillStrategy(StepContext ctx)
        {
            return new RandomFillPercentStrategy(RandomFactory.Create(), ctx.RandomFillPercent);
        }

        private static CellMatrix CreateCellMatrix(StepContext ctx)
        {
            return new CellMatrix(ctx.Width, ctx.Height, ctx.BorderSize);
        }
    }
}