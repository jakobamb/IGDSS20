using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Tile;
using static GameManager;

public class ProductionBuilding : MonoBehaviour {

    public enum BuildingTypes { Empty, Fishery, Lumberjack, Sawmill, SheepFarm, Knitters, PotatoFarm, Distillery };

    private GameManager _GM;

    #region Attributes
    public BuildingTypes _type; //The type of the building
    public int _upkeep; //The money cost per minute
    public int _buildCostMoney; //placement money cost
    public int _buildCostPlanks; //placement planks cost
    public Tile _tile; //Reference to the tile it is built on

    public float efficiencyValue; //Calculated based on the surrounding tile types
    public float resourceGenerationInterval; //If operating at 100% efficiency, this is the time in seconds it takes for one production cycle to finish
    public int _outputCount; //The number of output resources per generation cycle (for example the Sawmill produces 2 planks at a time)

    public List<TileTypes> _canBeBuiltOnTileTypes; //A restriction on which types of tiles it can be placed on
    public TileTypes _efficiencyScalesWithNeighboringTiles; //A choice if its efficiency scales with a specific type of surrounding tile
    public int[] _minMaxNeighbors; //The minimum and maximum number of surrounding tiles its efficiency scales with (0-6)

    public List<ResourceTypes> _inputResources; //A choice for input resource types (0, 1 or 2 types)
    public ResourceTypes _outputResource; //A choice for output resource type

    #endregion

    public bool CanBeBuiltOnTile(Tile T){
        return _canBeBuiltOnTileTypes.Contains(T._type);
    }

    private float timer;
    private float resTimer;

    void Awake(){
        _GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void inintilize(Tile parentTile)
    {
        _tile = parentTile;
        this.calculateEfficiency();
    }

    private void calculateEfficiency()
    {
        if (_minMaxNeighbors.Length == 0)
        {
            // no efficiency scaling -> always 1
            this.efficiencyValue = 1;
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
            this.efficiencyValue = 0;
        }
        else
        {
            this.efficiencyValue = (float) posInRange / range;
        }
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