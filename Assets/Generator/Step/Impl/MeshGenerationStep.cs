using Util.Procedural;

namespace Generator.Step.Impl
{
    public class MeshGenerationStep: IGenerationStep
    {
        public object Perform(StepContext ctx, object input)
        {
            return new MapMesh((SquareMatrix) input);
        }
    }
}