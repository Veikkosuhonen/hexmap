using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Hexagon
{
    public const float outerRadius = 1;

    public static readonly float innerRadius = outerRadius * Mathf.Cos(Mathf.Deg2Rad * 30f);
    
    public static bool IsInside(float x, float y, float radius) {
        var ir = innerRadius * radius;
        var k = Mathf.Tan(Mathf.Deg2Rad * 60f);

        var b = true;

        b &= y < 2 * ir;

        b &= y > -k * x + ir;
        b &= y < k * x + ir;

        b &= y < -k * x + 5 * ir;
        b &= y > k * x - 3 * ir;

        return b;
    }
}
