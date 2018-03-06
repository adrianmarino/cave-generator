using UnityEngine;

namespace Generator.Output
{
    public interface IOutput
    {
        void Render(MonoBehaviour behaviour);

        object Data { get; }
    }
}