using System.Collections.Generic;
using Procedural.Generator.Step;

namespace Procedural.Generator.Pipeline {
    public class GenerationPipeline {
        public object Perform(StepContext ctx, object initialInput = null) {
            var input = initialInput;
            object output = null;

            foreach (var step in steps){
                output = step.Perform(ctx, input);
                input = output;
            }

            return output;
        }

        private readonly List<IGenerationStep> steps;

        public GenerationPipeline(List<IGenerationStep> steps) {
            this.steps = steps;
        }
    }
}
