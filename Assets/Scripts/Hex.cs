using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{

    public Hex[] Neighbours = new Hex[6];
    public int XIndex, ZIndex;

    public Hex NE { get => Neighbours[0]; set { Neighbours[0] = value; } }
    public Hex E { get => Neighbours[1]; set { Neighbours[1] = value; } }
    public Hex SE { get => Neighbours[2]; set { Neighbours[2] = value; } }
    public Hex SW { get => Neighbours[3]; set { Neighbours[3] = value; } }
    public Hex W { get => Neighbours[4]; set { Neighbours[4] = value; } }
    public Hex NW { get => Neighbours[5]; set { Neighbours[5] = value; } }

    public HexType HexType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
