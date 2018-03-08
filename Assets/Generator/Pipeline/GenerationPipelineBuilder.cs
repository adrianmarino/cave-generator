using System.Collections.Generic;
using System.Linq;
using Generator.Step;
using Generator.Step.Impl;

namespace Generator.Generator
{
    public class GenerationPipelineBuilder
    {
        public GenerationPipeline Build(GenerationStep step)
        {
            var steps = step.AllLessThanOrEqualThis()
                .Select(it => generators[it])
                .ToList();

            return new GenerationPipeline(steps);
        }

        readonly IDictionary<GenerationStep, IGenerationStep> generators;

        public GenerationPipelineBuilder() {
            generators = new Dictionary<GenerationStep, IGenerationStep>();
            generators[ GenerationStep.Cells] = new CellsGenerationStep();
            generators[ GenerationStep.Squares] = new SquaresGenerationStep();
            generators[ GenerationStep.Mesh] = new MeshGenerationStep();
            generators[ GenerationStep.Walls] = new WallsGenerationStep();
        }
    }
}