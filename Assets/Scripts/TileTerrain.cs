using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTerrain : MonoBehaviour
{

    private static int diameter = 256;
    private static int size = 100;

    public static readonly float OuterDiameter = size * Hexagon.outerRadius * 2;
    public static readonly float InnerDiameter = size * Hexagon.innerRadius * 2;

    public Terrain terrain;

    void Awake()
    {
        if (terrain != null) { 
            terrain.terrainData.SetHoles(0, 0, holeMap);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static bool[,] holeMap = BuildHoleMap();

    private static bool[,] BuildHoleMap() {
        var holeMap = new bool[diameter, diameter];
        for (int i = 0; i < diameter; i++) {
            for (int j = 0; j < diameter; j++) {
                holeMap[j, i] = Hexagon.IsInside(j, i, diameter / 2);
            }
        }
        return holeMap;
    }
}
