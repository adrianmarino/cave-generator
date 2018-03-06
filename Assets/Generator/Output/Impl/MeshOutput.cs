using UnityEngine;

namespace Generator.Output.Impl
{
    public class MeshOutput: Output<Mesh>
    {
        public override void Render(MonoBehaviour behaviour)
        {
            var meshFilter = behaviour.GetComponent<MeshFilter>();
            meshFilter.transform.localPosition = new Vector3(0, 2.5f, 0.5f);
            meshFilter.mesh = data;
        }

        public MeshOutput(Mesh mesh): base(mesh)
        {
        }
    }
}