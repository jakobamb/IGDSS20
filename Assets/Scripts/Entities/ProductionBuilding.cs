using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Tile;
using static GameManager;

public class ProductionBuilding : Building {
    
    #region ProductionAttributes
    public float efficiencyValue; //Calculated based on the surrounding tile types
    public float resourceGenerationInterval; //If operating at 100% efficiency, this is the time in seconds it takes for one production cycle to finish
    public int _outputCount; //The number of output resources per generation cycle (for example the Sawmill produces 2 planks at a time)

    public TileTypes _efficiencyScalesWithNeighboringTiles; //A choice if its efficiency scales with a specific type of surrounding tile
    public int[] _minMaxNeighbors; //The minimum and maximum number of surrounding tiles its efficiency scales with (0-6)

    public List<ResourceTypes> _inputResources; //A choice for input resource types (0, 1 or 2 types)
    public ResourceTypes _outputResource; //A choice for output resource type
    #endregion

    public override void Inintilize(Tile parentTile)
    {
        base.Inintilize(parentTile);
        calculateEfficiency();
    }

    private float timer;
    private float resTimer;
    private void calculateEfficiency()
    {
        if (_minMaxNeighbors.Length == 0)
        {
            // no efficiency scaling -> always 1
            efficiencyValue = 1;
            return;
        }

        int tileCount = 0;

        foreach (Tile t in _tile._neighborTiles)
        {
            if (t._type == _efficiencyScalesWithNeighboringTiles) { tileCount++; }
        }

        int range = _minMaxNeighbors[1] - _minMaxNeighbors[0];
        int posInRange = tileCount - _minMaxNeighbors[0];

        if (posInRange <= 0)
        {
            efficiencyValue = 0;
        }
        else
        {
            efficiencyValue = (float) posInRange / range;
        }
    }

    protected override void Start()
    {
        base.Start();
    }


    void Update(){
        timer = Time.deltaTime;
        resTimer += timer * efficiencyValue;

        if (resTimer >= resourceGenerationInterval){
            //add output to warehouse
            _GM.putResourceInWarehouse(_outputResource, _outputCount);
            
            //get input from warehouse
            foreach (ResourceTypes r in _inputResources)
            {
                _GM.removeResourceFromWarehouse(r, 1);
            }

            resTimer = 0;
        }
    }
}