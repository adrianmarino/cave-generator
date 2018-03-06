using UnityEngine;
using Util;
using Util.Procedural;

[HelpURL("https://en.wikipedia.org/wiki/Marching_squares")]
public class CaveGenerator : MonoBehaviour
{
    private void Start()
    {
        var random = RandomFactory.Create();
        
        cells = new CellMatrix(width, height)
            .Fill(random, randomFillPercent)
            .Smooth(smoothSteps, maxActiveNeighbors, neighboursRadio);

        squares = SquareMatrixFactory.Create(cells, squadSide);

        if (step == Step.Mesh)
            ShowMesh(MeshFactory.Create(squares));
    }

    private void OnDrawGizmos()
    {
        if(step == Step.Square) squares.ForEach(GizmosUtil.DrawSquare);
        if(step == Step.Cell) cells.ForEach(cell => GizmosUtil.DrawCell(cells, cell));
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            Start();
    }

    private void ShowMesh(Mesh mesh)
    {
        GetComponent<MeshFilter>().mesh = mesh;
    }

    #region Attributes
    
    private enum Step
    {
        Cell,
        Square,
        Mesh
    }

    [Header("Generation")]
    
    [Tooltip("Select the step of map construction.")]
    [SerializeField] Step step;

    [Header("Size")]
    
    [Tooltip("Height of Map.")]
    [SerializeField] int width;

    [Tooltip("Height of Map.")]
    [SerializeField] int height;
    
    [Space(10)]
    [Header("Cell Generation Phase")]
    
    [Tooltip("Set cell active(Value=1) when a random value is less than this.")]
    [SerializeField] [Range(0, 100)] int randomFillPercent;

    [Header("Smooth")]

    [Tooltip("Times that execute Smooth map filter.")]
    [SerializeField]
    int smoothSteps;

    [Tooltip("Max number of active neighbors cells. Used to set current cell as active(cell.Value=1) when reach max or inactive(cell.Value=0) when do not.")]
    [SerializeField]
    int maxActiveNeighbors;

    [Tooltip("Radial cells count from curent cell. Used to determine MaxActiveNeighbors of a cell.")]
    [SerializeField]
    int neighboursRadio;

    [Space(10)]
    [Header("Square Generation Phase")]

    [Tooltip("Square size size. Used for 'Matching Squares Method'")]

    [SerializeField] [Range(0, 10)]
    float squadSide;
    
    
    private CellMatrix cells;

    private SquareMatrix squares;

    #endregion

    public CaveGenerator()
    {
        width = 100;
        height = 50;
        randomFillPercent = 45;
        smoothSteps = 5;
        maxActiveNeighbors = 4;
        neighboursRadio = 1;
        squadSide = 1;
    }
}
