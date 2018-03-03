using System;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    void Start()
    {
        map = Generate(width, height);
    }

    int[,] Generate(int width, int height)
    {
        var map = new int[width, height];
        var random = CreateRandom();

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++) {
                if (IsAndEdge(x, y)) 
                    map[x, y] = 1; 
                else 
                    map[x, y] = random.Next(0, 100) < randomFillPercent ? 1 : 0;
            }

        return map;
    }

    double CurrentMillis()
    {
        return (DateTime.Now - DateTime.MinValue).TotalMilliseconds;
        
    }
    
    System.Random CreateRandom()
    {
        var seed = CurrentMillis().GetHashCode();
        Debug.LogFormat("Seed: {0}", seed);
        return new System.Random(seed);
    }

    private void OnDrawGizmos()
    {
        if (map == null) return;
        Draw(map, width, height);
    }

    static void Draw(int[,] map, int width, int height)
    {
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                Gizmos.color = map[x, y] == 1 ? Color.black : Color.white;
                Vector3 position = new Vector3(-width/2 + x + .5f, 0, -height/2 + y + .5f);
                Gizmos.DrawCube(position, Vector3.one);
            }
    }

    private bool IsAndEdge(int x, int y)
    {
        return x == 0 || y == 0 || x == width - 1 || y == height - 1;
    }

    #region Attributes

    [SerializeField] int width;

    [SerializeField] int height;

    [SerializeField] [Range(0, 100)] int randomFillPercent;

    int[,] map;
    
    #endregion

    public MapGenerator()
    {
        width = 60;
        height = 80;
        randomFillPercent = 50;
    }
}
