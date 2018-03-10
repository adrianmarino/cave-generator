using Util.Procedural;

namespace Generator.Step.Impl
{
    public class WallsGenerationStep: IGenerationStep
    {
        public object Perform(StepContext ctx, object data)
        {
            
            var mapMesh = GetInput(data);

            var edges = OutlineEdgeFactory.extarctFrom(mapMesh);

            var wallMesh = WallMeshFactory.Create(edges, wallHeight);
            
            return new[] {mapMesh, wallMesh};
        }

        private static IMesh GetInput(object data)
        {
            var meshes = (IMesh[]) data;
            return meshes[0];
        }

        const int wallHeight = 5;
    }
}