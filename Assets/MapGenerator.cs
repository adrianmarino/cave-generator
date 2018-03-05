using UnityEngine;
using Util;
using Util.Procedural;

public class MapGenerator : MonoBehaviour
{
    void Start()
    {
        var cellMatrix = new CellMatrix(width, height)
            .Fill(RandomFactory.Create(), randomFillPercent)
            .Smooth(smoothSteps, maxWallCount, neighbourOffset);

        squares = new SquareEdgeNodeMatrix(cellMatrix, squadSide).AsSquareMatrix();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) Start();
    }

    private void OnDrawGizmos()
    {
        if (squares != null) squares.ForEach(GizmosUtil.DrawSquare);
    }

    #region Attributes

    [SerializeField] int width;

    [SerializeField] int height;

    [SerializeField] int smoothSteps;

    [SerializeField] int maxWallCount;
        
    [SerializeField] int neighbourOffset;

    [SerializeField] [Range(0, 10)] float squadSide;
    
    [SerializeField] [Range(0, 100)] int randomFillPercent;

    SquareMatrix squares;
    
    #endregion

    public MapGenerator()
    {
        width = 120;
        height = 72;
        randomFillPercent = 45;
        smoothSteps = 7;
        maxWallCount = 4;
        neighbourOffset = 1;
        squadSide = 1;
    }
}
