using Util.Procedural;

namespace Generator.Step.Impl
{
    public class MeshGenerationStep: IGenerationStep
    {
        public object Perform(StepContext ctx, object input)
        {
            var squares =GetInput(input);
            var mesh = new MapMesh(squares);
            return new IMesh[] {mesh};
        }

        private static SquareMatrix GetInput(object input)
        {
            return (SquareMatrix) input;
        }
    }
}