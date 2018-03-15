using System;
using System.Collections.Generic;
using System.Linq;

namespace Procedural.Generator.Pipeline {
    internal static class GenerationStepMethods {
        public static List<GenerationStep> AllLessThanOrEqualThis(this GenerationStep stepEnum) {
            return Enum.GetValues(typeof(GenerationStep)).Cast<GenerationStep>().Where(it => it <= stepEnum).ToList();
        }
    }

    public enum GenerationStep {
        Cells = 0,
        Squares = 1,
        Map = 2,
        Walls = 3
    }
}
