using Procedural.Model;

namespace Procedural.Generator.Step.Impl
{
    public class MeshGenerationStep: IGenerationStep
    {
        public object Perform(StepContext ctx, object input)
        {
            var squares = GetInput(input);
            var mapMesh = new MapMeshFactory().Create(squares);
            return new[] {mapMesh};
        }

        private static SquareMatrix GetInput(object input)
        {
            return (SquareMatrix) input;
        }
    }
}