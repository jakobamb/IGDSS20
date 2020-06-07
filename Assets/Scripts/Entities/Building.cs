using UnityEngine;
using static Tile;

public class Building : MonoBehaviour {

    #region Attributes
    public BuildingTypes _type; //The type of the building
    public int _upkeep; //The money cost per minute
    public int _buildCostMoney; //placement money cost
    public int _buildCostPlanks; //placement planks cost
    public Tile _tile; //Reference to the tile it is built on

    public float efficiencyValue; //Calculated based on the surrounding tile types
    public float resourceGenerationInterval; //If operating at 100% efficiency, this is the time in seconds it takes for one production cycle to finish
    public int _output_Count; //The number of output resources per generation cycle (for example the Sawmill produces 2 planks at a time)

    public List<TileTypes> _canBeBuiltOnTileTypes; //A restriction on which types of tiles it can be placed on
    public TileTypes _efficiencyScalesWithNeighboringTiles; //A choice if its efficiency scales with a specific type of surrounding tile
    public int[] _minMaxNeighbors; //The minimum and maximum number of surrounding tiles its efficiency scales with (0-6)

    public List<ResourceTypes> _inputResources; //A choice for input resource types (0, 1 or 2 types)
    public ReourceTypes _outputResource; //A choice for output resource type

    #endregion

    public static bool CanBeBuiltOnTile(TileTypes T){
        return _canBeBuiltOnTileTypes.Contains(T._type);
    }
}