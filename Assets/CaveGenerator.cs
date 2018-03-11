using System.Collections.Generic;
using System.Linq;
using Generator.Generator;
using Generator.Step;
using UnityEngine;
using Util;
using Util.Procedural;

namespace Generator
{
    [HelpURL("https://en.wikipedia.org/wiki/Marching_squares")]
    public class CaveGenerator : MonoBehaviour
    {
        private void Start()
        {
            Generate();
        }

        private void OnDrawGizmos()
        {
            Render(RenderEvent.OnDrawGizmos);
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;

            Generate();
            Render(RenderEvent.Update);
        }

        private void Generate()
        {
            CleanView();
            var ctx = CreateStepContext();
            var pipeline = pipelineBuilder.Build(step);
            output = pipeline.Perform(ctx);
        }
        
        private void Render(RenderEvent renderEvent)
        {
            var ctx = new RenderContext(renderEvent, output, this);
            rendererService.Render(ctx);
        }

        private StepContext CreateStepContext()
        {
            return new StepContext(
                width, 
                height, 
                randomFillPercent, 
                smoothSteps, 
                maxActiveNeighbors, 
                neighboursRadio, 
                squadSide
            );
        }

        public void CleanView()
        {
            MeshFilters.ForEach(it => it.mesh.Clear());
        }

        public void Show(IList<IMesh> meshes)
        {
            for (var index = 0; index < meshes.Count; index++)
                MeshFilters[index].mesh = meshes[index].asUnityMesh();
        }
        
        #region Properties
        
        public MeshFilter[] MeshFilters
        {
            get
            {
                return new [] {GetComponent<MeshFilter>(), wallsMeshFilter}.Where(it => it != null).ToArray();
            }
        }
        
        public Camera Camera
        {
            get
            {
                return sceneCamera; 
            }
        }

        public GenerationStep Step
        {
            get { return step; }
        }

        #endregion
        
        #region Attributes

        [Header("Generation")] [Tooltip("Select the step of map construction.")] [SerializeField]
        GenerationStep step;
        
        [Tooltip("Scene Camera")]
        [SerializeField]
        Camera sceneCamera;

        [Tooltip("Map filter of Walls inner object.")]
        [SerializeField]
        MeshFilter wallsMeshFilter;
        
        [Header("Size")] [Tooltip("Height of Map.")] [SerializeField]
        int width;

        [Tooltip("Height of Map.")] [SerializeField]
        int height;

        [Space(10)]
        [Header("Cells Generation Step")]
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
        [Header("Squares Generation Step")]
        [Tooltip("Square size size. Used for 'Matching Squares Method'")]
        [SerializeField]
        [Range(0, 10)]
        float squadSide;
        
        object output;

        readonly RendererService rendererService;
        
        readonly GenerationPipelineBuilder pipelineBuilder;
        
        #endregion

        public CaveGenerator()
        {
            output = null;
            sceneCamera = null;
            wallsMeshFilter = null;
            step = GenerationStep.Cells;
            width = 120;
            height = 40;
            randomFillPercent = 45;
            smoothSteps = 5;
            maxActiveNeighbors = 4;
            neighboursRadio = 1;
            squadSide = 1;
            rendererService = new RendererService();
            pipelineBuilder = new GenerationPipelineBuilder();
        }
    }
}