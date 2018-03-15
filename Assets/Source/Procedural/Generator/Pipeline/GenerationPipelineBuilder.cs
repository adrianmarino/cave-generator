using System.Collections.Generic;
using System.Linq;
using Procedural.Generator.Step;
using Procedural.Generator.Step.Impl;

namespace Procedural.Generator.Pipeline
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
            generators[ GenerationStep.Map] = new MeshGenerationStep();
            generators[ GenerationStep.Walls] = new WallsGenerationStep();
        }
    }
}