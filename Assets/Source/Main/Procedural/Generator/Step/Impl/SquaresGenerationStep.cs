using Procedural.Model;

namespace Procedural.Generator.Step.Impl {
    public class SquaresGenerationStep : IGenerationStep {
        public object Perform(StepContext ctx, object input) {
            return SquareMatrixFactory.Create((CellMatrix) input, ctx.SquadSide);
        }
    }
}