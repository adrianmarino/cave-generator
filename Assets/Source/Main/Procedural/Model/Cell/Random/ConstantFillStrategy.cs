namespace Procedural.Model {
    public class ConstantFillStrategy : IFillStrategy {
        public CellValue Next() {
            return value;
        }

        private readonly CellValue value;

        public ConstantFillStrategy(CellValue value) {
            this.value = value;
        }
    }
}
