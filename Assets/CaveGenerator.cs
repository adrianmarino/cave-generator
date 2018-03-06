using Generator.Generator;
using Generator.Output;
using Generator.Step;
using UnityEngine;

namespace Generator
{
    [HelpURL("https://en.wikipedia.org/wiki/Marching_squares")]
    public class CaveGenerator : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            if(output != null) output.Render(this);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) output = Generate();
        }

        private IOutput Generate()
        {
            CleanMesh();
            var ctx = CreateStepContext();
            var pipeline = pipelineBuilder.Build(step);
            return pipeline.Perform(ctx);
        }

        private void CleanMesh()
        {
            GetComponent<MeshFilter>().mesh = new Mesh();
        }

        private StepContext CreateStepContext()
        {
            return new StepContext(width, height, randomFillPercent, smoothSteps, maxActiveNeighbors, neighboursRadio, squadSide);
        }

        #region Attributes

        [Header("Generation")] [Tooltip("Select the step of map construction.")] [SerializeField]
        GenerationStep step;

        [Header("Size")] [Tooltip("Height of Map.")] [SerializeField]
        int width;

        [Tooltip("Height of Map.")] [SerializeField]
        int height;

        [Space(10)]
        [Header("Cell Generation Phase")]
        [Tooltip("Set cell active(Value=1) when a random value is less than this.")]
        [SerializeField]
        [Range(0, 100)]
        int randomFillPercent;

        [Header("Smooth")] [Tooltip("Times that execute Smooth map filter.")] [SerializeField]
        int smoothSteps;

        [Tooltip(
            "Max number of active neighbors cells. Used to set current cell as active(cell.Value=1) when reach max or inactive(cell.Value=0) when do not.")]
        [SerializeField]
        int maxActiveNeighbors;

        [Tooltip("Radial cells count from curent cell. Used to determine MaxActiveNeighbors of a cell.")]
        [SerializeField]
        int neighboursRadio;

        [Space(10)]
        [Header("Square Generation Phase")]
        [Tooltip("Square size size. Used for 'Matching Squares Method'")]
        [SerializeField]
        [Range(0, 10)]
        float squadSide;

        IOutput output;
        
        readonly GenerationPipelineBuilder pipelineBuilder;
        
        #endregion

        public CaveGenerator()
        {
            step = GenerationStep.Cell;
            width = 120;
            height = 40;
            randomFillPercent = 45;
            smoothSteps = 5;
            maxActiveNeighbors = 4;
            neighboursRadio = 1;
            squadSide = 1;
            pipelineBuilder = new GenerationPipelineBuilder();
        }
    }
}