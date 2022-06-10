using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour
{

    

    public int width = 6;
    public int height = 6;

	public List<GameObject> tiles;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	GameObject[] cells;

	void Awake() {
		cells = new GameObject[height * width];

		for (int z = 0, i = 0; z < height; z++) {
			for (int x = 0; x < width; x++) {
				CreateCell(x, z, i++);
			}
		}
	}

	void CreateCell(int x, int z, int i) {
		Vector3 position;
		position.x = (x + z * 0.5f - z / 2) * Tile.InnerDiameter;
		position.y = Random.value * 0.3f;
		position.z = z * Tile.OuterDiameter / 2 * 1.5f;

		GameObject cell = cells[i] = Instantiate(tiles[Mathf.FloorToInt(Random.value * tiles.Count)]);
		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;
	}
}
