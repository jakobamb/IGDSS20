using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public Texture2D heightmap;
    public List<Tile> tilesForest;
    public List<Tile> tilesGrass;
    public List<Tile> tilesSand;
    public List<Tile> tilesMountain;
    public List<Tile> tilesStone;
    public List<Tile> tilesWater;

    public float heightmapSteepness;

    private Tile spawnTile(Vector3 pos, float hmapVal) 
    {
        float height = pos[1];
        Quaternion rotation = Quaternion.AngleAxis(60 * Random.Range(0, 6), Vector3.up);
        Tile selectedTile;
        if (hmapVal == 0) {
            selectedTile = Helpers.RandomListSelect(tilesWater);
        } else if (hmapVal <= 0.2) {
            selectedTile = Helpers.RandomListSelect(tilesSand);
        } else if (hmapVal <= 0.4) {
            selectedTile = Helpers.RandomListSelect(tilesGrass);
        } else if (hmapVal <= 0.6) {
            selectedTile = Helpers.RandomListSelect(tilesForest);
        } else if (hmapVal <= 0.8) {
            selectedTile = Helpers.RandomListSelect(tilesStone);
        } else {
            selectedTile = Helpers.RandomListSelect(tilesMountain);
        }
        GameObject newTile = Instantiate(selectedTile.gameObject, pos, rotation);
        return (Tile)newTile.GetComponent("Tile");
    }

    public Vector2 getMapBounds() {
        return new Vector2(0f, heightmap.width * 12f);
    }

    public Tile[,] generateMap()
    {
        Tile[,] tileMap = new Tile[heightmap.height, heightmap.width];

        // iterate through the heightmap pixels
        for (int x = 0; x < heightmap.height; x++) {
            for (int z = 0; z < heightmap.width; z++) {
                // every other row has an offset
                float tile_offset = (x%2 == 0 ? 0 : 5);
                float heightmap_value = heightmap.GetPixel(z, x).grayscale;
                float tileHeight = heightmap_value * heightmapSteepness;
                Vector3 tilePos = new Vector3(x * 8.66f, tileHeight, tile_offset + z * 10);
                Tile newTile = spawnTile(tilePos, heightmap_value);
                tileMap[x, z] = newTile;
            }
        }

        return tileMap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}