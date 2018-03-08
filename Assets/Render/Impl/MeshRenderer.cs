using Generator.Generator;
using UnityEditor.Sprites;
using UnityEngine;
using Util.Procedural;

namespace Generator.Output.Impl
{
    public class MeshRenderer: IRenderer
    {
        public void Render(MonoBehaviour behaviour, object data)
        {
            var mapMesh = (MapMesh) data;
            var meshFilter = behaviour.GetComponent<MeshFilter>();
            meshFilter.transform.localPosition = new Vector3(0, 2.5f, 0.5f);
            meshFilter.mesh = mapMesh.asMesh();
        }

        public bool CanRender(object data)
        {
            return typeof(MapMesh) == data.GetType();
        }
    }
}