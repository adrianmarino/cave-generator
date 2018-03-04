using UnityEngine;
using Util;
using Util.Procedural;

public class MapGenerator : MonoBehaviour
{
    void Start()
    {
        map = new ProceduralMap(width, height)
            .Fill(RandomFactory.Create(), randomFillPercent)
            .Smooth(smoothSteps, maxWallCount, neighbourOffset);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            Start();
    }

    private void OnDrawGizmos()
    {
        if (map == null) return;
        map.ForEach(point => GizmosUtil.DrawPoint(map, point));
    }

    #region Attributes

    [SerializeField] int width;

    [SerializeField] int height;

    [SerializeField] int smoothSteps;

    [SerializeField] int maxWallCount;
        
    [SerializeField] int neighbourOffset;

    [SerializeField] [Range(0, 100)] int randomFillPercent;

    ProceduralMap map;
    
    #endregion

    public MapGenerator()
    {
        width = 120;
        height = 72;
        randomFillPercent = 45;
        smoothSteps = 7;
        maxWallCount = 4;
        neighbourOffset = 1;
    }
}
