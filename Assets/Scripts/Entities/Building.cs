using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Tile;
using static GameManager;


public abstract class Building : MonoBehaviour
{
    public enum BuildingTypes { Empty, Fishery, Lumberjack, Sawmill, SheepFarm, Knitters, PotatoFarm, Distillery };

    #region Attributes
    public BuildingTypes _type; //The type of the building
    public int _upkeep; //The money cost per minute
    public int _buildCostMoney; //placement money cost
    public int _buildCostPlanks; //placement planks cost
    public Tile _tile; //Reference to the tile it is built on
    public List<TileTypes> _canBeBuiltOnTileTypes; //A restriction on which types of tiles it can be placed on
    #endregion

    #region Manager References
    protected JobManager _jobManager; //Reference to the JobManager
    protected GameManager _GM; // Reference to the GameManager
    #endregion

    #region Workers
    public List<Worker> _workers; //List of all workers associated with this building, either for work or living
    #endregion

    #region Jobs
    public List<Job> _jobs; // List of all available Jobs. Is populated in Start()
    #endregion

    #region Methods   

    // <summary> Initilize needs to be called on any instantiated tile before it is used. </summary>
    public virtual void Inintilize(Tile parentTile)
    {
        _tile = parentTile;
    }

    public bool CanBeBuiltOnTile(Tile T)
    {
        return _canBeBuiltOnTileTypes.Contains(T._type);
    }


    public void WorkerAssignedToBuilding(Worker w)
    {
        _workers.Add(w);
    }

    public void WorkerRemovedFromBuilding(Worker w)
    {
        _workers.Remove(w);
    }
    #endregion

    protected virtual void Start()
    {
        _GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
}
