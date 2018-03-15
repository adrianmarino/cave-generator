namespace Util {
    public interface ITwoDimensionIndexable<out ELEMENT> {
        ELEMENT this[int x, int y] { get; }
    }
}