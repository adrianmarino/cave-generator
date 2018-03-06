
using UnityEngine;

namespace Generator.Output
{
    public abstract class Output<DATA>: IOutput
    {
        public abstract void Render(MonoBehaviour behaviour);

        public object Data
        {
            get { return data; }
        }

        protected readonly DATA data;

        protected Output(DATA data)
        {
            this.data = data;
        }
    }
}