using Generator.Generator;
using UnityEngine;

namespace Generator.Output.Impl
{
    public class EmptyRenderer: IRenderer
    {
        public void Render(MonoBehaviour behaviour, object data)
        {
            behaviour.GetComponent<MeshFilter>().mesh = new Mesh();
        }

        public bool CanRender(object data)
        {
            return data == null;
        }
    }
}