﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    #region Attributes
    public TileTypes _type; //The type of the tile
    public int _navigationWeight; //The resistance a tile has to traversel. Higher numbers mean it is harder to walk over this tile
    public Building _building; //The building on this tile
    public List<Tile> _neighborTiles; //List of all surrounding tiles. Generated by GameManager
    public int _coordinateHeight; //The coordinate on the y-axis on the tile grid (not world coordinates)
    public int _coordinateWidth; //The coordinate on the x-axis on the tile grid (not world coordinates)
    #endregion

    #region Enumerations
    public enum TileTypes { Empty, Water, Sand, Grass, Forest, Stone, Mountain }; //Enumeration of all available tile types. Can be addressed from other scripts by calling Tile.Tiletypes
    #endregion

    //This class acts as a data container and has no functionality
}
