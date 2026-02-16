using UnityEngine;

public class Tile
{
    private GridSystem<Tile> _grid;
    public TileType type;
    public int x;
    public int z;

    public bool isActive;

    public GameObject tileObject;

    

    public Tile(GridSystem<Tile> grid, int x, int z)
    {
        _grid = grid;
        this.x = x;
        this.z = z;
    }

    public TileType GetTileType()
    {
        if(type == default) SetRandomTileType();
        return type;
    }

    public void SetRandomTileType()
    {
        TileType type;

        type = (TileType)Random.Range(0, System.Enum.GetValues(typeof(TileType)).Length);
        this.type = type;
    }
}
