using Generator.Output;
using Generator.Output.Impl;
using UnityEngine;
using Util.Procedural;

namespace Generator.Step.Impl
{
    public class MeshGenerationStep: IGenerationStep
    {
        public IOutput Perform(StepContext ctx, object input)
        {
            var mapMesh = new MapMesh((SquareMatrix) input);
            var unityMesh = mapMesh.asMesh();
            return new MeshOutput(unityMesh);
        }
    }
}