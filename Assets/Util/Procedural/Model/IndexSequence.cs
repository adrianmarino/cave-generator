namespace Util.Procedural
{
    public class IndexSequence
    {
        public override string ToString()
        {
            return string.Format("Index: {0}", value);
        }

        public int Next()
        {
            return value++;
        }

        private int value;

        public IndexSequence(int value)
        {
            this.value = value;
        }
    }
}