namespace Procedural.Generator.Step
{
    public class StepContext
    {
        public int Height { get; private set; }

        public int Width { get; private set; }
        
        public int NeighboursRadio { get; private set; }

        public float SquadSide { get; private set; }

        public int MaxActiveNeighbors { get; private set; }

        public int SmoothSteps { get; private set; }

        public int RandomFillPercent { get; private set; }
        
        public int RemoveRegionsSize { get; private set; }
        
        public int BorderSize { get; private set; }

        public StepContext(
            int width, 
            int height, 
            int randomFillPercent, 
            int smoothSteps,
            int maxActiveNeighbors, 
            int neighboursRadio, 
            float squadSide,
            int removeRegionsSize,
            int borderSize
        )
        {
            Width = width;
            Height = height;
            RandomFillPercent = randomFillPercent;
            SmoothSteps = smoothSteps;
            MaxActiveNeighbors = maxActiveNeighbors;
            NeighboursRadio = neighboursRadio;
            SquadSide = squadSide;
            RemoveRegionsSize = removeRegionsSize;
            BorderSize = borderSize;
        }
    }
}