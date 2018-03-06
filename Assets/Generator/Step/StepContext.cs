namespace Generator.Step
{
    public class StepContext
    {
        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public int RandomFillPercent
        {
            get { return randomFillPercent; }
        }

        public int SmoothSteps
        {
            get { return smoothSteps; }
        }

        public int MaxActiveNeighbors
        {
            get { return maxActiveNeighbors; }
        }

        public int NeighboursRadio
        {
            get { return neighboursRadio; }
        }

        public float SquadSide
        {
            get { return squadSide; }
        }

        readonly int width;
        readonly int height;
        readonly int randomFillPercent;
        readonly int smoothSteps;
        readonly int maxActiveNeighbors;
        readonly int neighboursRadio;
        readonly float squadSide;

        public StepContext(
            int width, int height, int randomFillPercent, int smoothSteps, 
            int maxActiveNeighbors, int neighboursRadio, float squadSide)
        {
            this.width = width;
            this.height = height;
            this.randomFillPercent = randomFillPercent;
            this.smoothSteps = smoothSteps;
            this.maxActiveNeighbors = maxActiveNeighbors;
            this.neighboursRadio = neighboursRadio;
            this.squadSide = squadSide;
        }
    }
}