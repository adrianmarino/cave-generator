using UnityEngine;

namespace Generator.Output.Impl
{
    public class MeshOutput: Output<Mesh>
    {
        public override void Render(MonoBehaviour behaviour)
        {
            var meshFilter = behaviour.GetComponent<MeshFilter>();
            meshFilter.mesh = data;
        }

        public MeshOutput(Mesh mesh): base(mesh)
        {
        }
    }
}