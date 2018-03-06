using System.Collections.Generic;
using System.Linq;
using Generator.Output;
using Generator.Step;

namespace Generator.Generator
{
    public class GenerationPipeline
    {
        public IOutput Perform(StepContext ctx)
        {
            return Perform(ctx, null);
        }

        public IOutput Perform(StepContext ctx, object initialInput)
        {
            var input = initialInput;
            IOutput output = null;

            foreach (var step in steps)
            {
                output = step.Perform(ctx, input);
                input = output.Data;
            }

            return output;
        }
        
        private readonly List<IGenerationStep> steps;

        public GenerationPipeline(List<IGenerationStep> steps)
        {
            this.steps = steps;
        }
    }
}