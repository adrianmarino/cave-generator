using Generator.Output;
using Generator.Output.Impl;
using Util.Procedural;

namespace Generator.Step.Impl
{
    public class SquaresGenerationStep: IGenerationStep
    {
        public IOutput Perform(StepContext ctx, object input)
        {
            var squareMatrix = SquareMatrixFactory.Create((CellMatrix)input, ctx.SquadSide);
            return new SquaresOutput(squareMatrix);
        }
    }
}