namespace Generator.Step
{
    public class StepContext
    {
        public int Height { get; private set; }

        public int Width { get; private set; }
        
        public int NeighboursRadio { get; set; }

        public float SquadSide { get; set; }

        public int MaxActiveNeighbors { get; set; }

        public int SmoothSteps { get; set; }

        public int RandomFillPercent { get; set; }

        public StepContext(
            int width, 
            int height, 
            int randomFillPercent, 
            int smoothSteps,
            int maxActiveNeighbors, 
            int neighboursRadio, 
            float squadSide
        )
        {
            Width = width;
            Height = height;
            RandomFillPercent = randomFillPercent;
            SmoothSteps = smoothSteps;
            MaxActiveNeighbors = maxActiveNeighbors;
            NeighboursRadio = neighboursRadio;
            SquadSide = squadSide;
        }
    }
}