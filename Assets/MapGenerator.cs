using UnityEngine;
using Util;

public class MapGenerator : MonoBehaviour
{
    void Start()
    {
        map = new Map(width, height)
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

    Map map;
    
    #endregion

    public MapGenerator()
    {
        width = 60;
        height = 80;
        randomFillPercent = 50;
        smoothSteps = 5;
        maxWallCount = 4;
        neighbourOffset = 1;
    }
}
