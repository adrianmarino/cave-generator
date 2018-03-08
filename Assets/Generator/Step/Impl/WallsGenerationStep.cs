using Util.Procedural;

namespace Generator.Step.Impl
{
    public class WallsGenerationStep: IGenerationStep
    {
        public object Perform(StepContext ctx, object input)
        {
            var mapMesh = (MapMesh)input;

            return mapMesh;
        }
    }
}