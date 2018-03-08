using UnityEngine;

namespace Generator.Generator
{
    public interface IRenderer
    {
        void Render(MonoBehaviour behaviour, object data);

        bool CanRender(object data);
    }
}