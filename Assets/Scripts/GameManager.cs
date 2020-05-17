using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine; 

public class GameManager : MonoBehaviour
{
    public Texture2D heightmap;
    public List<GameObject> tilesForest;
    public List<GameObject> tilesGrass;
    public List<GameObject> tilesSand;
    public List<GameObject> tilesMountain;
    public List<GameObject> tilesStone;
    public List<GameObject> tilesWater;

    public float heightmapSteepness;

    GameObject spawnTile(Vector3 pos, float hmapVal) 
    {
        float height = pos[1];
        Quaternion rotation = Quaternion.AngleAxis(60 * Random.Range(0, 6), Vector3.up);
        if (hmapVal == 0) {
            return Instantiate(Helpers.randomListSelect(tilesWater), pos, rotation);
        } else if (hmapVal <= 0.2) {
            return Instantiate(Helpers.randomListSelect(tilesSand), pos, rotation);
        } else if (hmapVal <= 0.4) {
            return Instantiate(Helpers.randomListSelect(tilesGrass), pos, rotation);
        } else if (hmapVal <= 0.6) {
            return Instantiate(Helpers.randomListSelect(tilesForest), pos, rotation);
        } else if (hmapVal <= 0.8) {
            return Instantiate(Helpers.randomListSelect(tilesStone), pos, rotation);
        } else {
            return Instantiate(Helpers.randomListSelect(tilesMountain), pos, rotation);
        }
    }

    public Vector2 getMapBounds() {
        return new Vector2(0f, heightmap.width * 12f);
    }

    // Start is called before the first frame update
    void Start()
    {
        // iterate through the heightmap pixels
        for (int x = 0; x < heightmap.height; x++) {
            for (int z = 0; z < heightmap.width; z++) {
                // every other row has an offset
                float tile_offset = (x%2 == 0 ? 0 : 5);
                float heightmap_value = heightmap.GetPixel(z, x).grayscale;
                float tileHeight = heightmap_value * heightmapSteepness;
                Vector3 tilePos = new Vector3(x * 8.66f, tileHeight, tile_offset + z * 10);
                spawnTile(tilePos, heightmap_value);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
