using System.Linq;
using NUnit.Framework;
using Procedural.Model;

namespace Source.Test {    
    [TestFixture]
    public class CellMatrixTest {
        [Test]
        public void FindOnlyOneRegion() {
            // Prepare
            const int width = 20;
            const int height = 10;
            const int borderSize = 1;
            const CellValue cellValue = CellValue.Floor;
            IFillStrategy fillStrategy = new ConstantFillStrategy(cellValue);
            var matrix = new CellMatrix(width, height, borderSize).Fill(fillStrategy);

            // Perform
            var regions = matrix.RegionsBy(cellValue);

            // Asserts
            Assert.AreEqual(1, regions.Count());
        }
    }
}
