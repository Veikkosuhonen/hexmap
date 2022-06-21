using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HexMap : MonoBehaviour
{


	[SerializeField]
	private int Width = 6;

	[SerializeField]
	private int Height = 6;

	[SerializeField]
	private List<GameObject> Tiles;

	Hex[] hexes;

    public void Generate() {
		ResetMap();

		for (int z = 0, i = 0; z < Height; z++) {
			for (int x = 0; x < Width; x++) {
				CreateHex(x, z, i++);
			}
		}

		foreach (var hex in hexes) {

			var xOffset = hex.ZIndex % 2 == 0 ? 0 : 1;

			hex.NE = hexes.FirstOrDefault(cell => cell.ZIndex == hex.ZIndex + 1 && cell.XIndex == hex.XIndex - xOffset);
			hex.E = hexes.FirstOrDefault(cell => cell.ZIndex == hex.ZIndex && cell.XIndex == hex.XIndex + 1);
			hex.SE = hexes.FirstOrDefault(cell => cell.ZIndex == hex.ZIndex - 1 && cell.XIndex == hex.XIndex + xOffset);
			hex.SW = hexes.FirstOrDefault(cell => cell.ZIndex == hex.ZIndex - 1 && cell.XIndex == hex.XIndex - (1 - xOffset));
			hex.W = hexes.FirstOrDefault(cell => cell.ZIndex == hex.ZIndex && cell.XIndex == hex.XIndex - 1);
			hex.NW = hexes.FirstOrDefault(cell => cell.ZIndex == hex.ZIndex + 1 && cell.XIndex == hex.XIndex - (1 - xOffset));
		}
	}

	void CreateHex(int x, int z, int i) {
		Vector3 position;
		position.x = (x + z * 0.5f - z / 2) * TileTerrain.InnerDiameter;
		position.y = Random.value * 0.3f;
		position.z = z * TileTerrain.OuterDiameter / 2 * 1.5f;

		GameObject cell = Instantiate(Tiles[Mathf.FloorToInt(Random.value * Tiles.Count)]);
		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;

		var hex = cell.GetComponent<Hex>();
		hex.XIndex = x;
		hex.ZIndex = z;

		hexes[i] = hex;
	}

    public void ResetMap() {
        hexes = new Hex[Width * Height];
		transform.GetComponentsInChildren<Hex>().Select(it => it.gameObject).ToList().ForEach(it => DestroyImmediate(it));
	}
}
