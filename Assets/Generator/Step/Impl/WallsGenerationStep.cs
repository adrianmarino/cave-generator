using Util.Procedural;

namespace Generator.Step.Impl
{
    public class WallsGenerationStep: IGenerationStep
    {
        public object Perform(StepContext ctx, object data)
        {
            
            var mapMesh = GetInput(data);
            var wallsMesh = new WallsMesh(mapMesh.OutlineEdges, wallHeight);
            return new IMesh[] {mapMesh, wallsMesh};
        }

        private static MapMesh GetInput(object data)
        {
            var meshes = (IMesh[]) data;
            return (MapMesh)meshes[0];
        }

        const int wallHeight = 5;
    }
}