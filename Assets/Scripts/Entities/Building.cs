using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Tile;
using static GameManager;

public class Building : MonoBehaviour {

    public enum BuildingTypes { Empty, Fishery, Lumberjack, Sawmill, SheepFarm, Knitters, PotatoFarm, Distillery };

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
    private float econTimer;
    private float resTimer;

    void Awake(){
        //subtract buildcostmoney and buildcostplanks 
    }

    void Update(){
        timer = Time.deltaTime;

        econTimer += timer;

        resTimer += timer * efficiencyValue;

        if (resTimer >= resourceGenerationInterval){
            //add output to warehouse
            //get input from warehouse
            resTimer = 0;
        }

        if (econTimer >= 60){
            //subtract upkeep from GM
            //money is not implement in the GM tho
            econTimer = 0;
        }
    }
}