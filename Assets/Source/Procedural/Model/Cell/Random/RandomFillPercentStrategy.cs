using Util;
using Random = System.Random;

namespace Procedural.Model {
    public class RandomFillPercentStrategy : IFillStrategy {
        public CellValue Next() {
            return random.Next(0, 100) < fillPercent ? CellValue.Wall : CellValue.Floor;
        }

        private readonly Random random;

        private readonly int fillPercent;

        public RandomFillPercentStrategy(Random random, int fillPercent) {
            this.random = random;
            this.fillPercent = fillPercent;
        }
    }
}