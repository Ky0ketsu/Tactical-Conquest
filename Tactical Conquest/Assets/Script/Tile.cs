using UnityEngine;

public class Tile
{
    public GridSystem<Tile> _grid;
    public GridGenerator gridGenerator;
    public TileType type;
    public int x;
    public int z;

    public bool isActive;

    public GameObject tileObject;

    [HideInInspector]
    public TileVisual tileVisual;

    

    public Tile(GridSystem<Tile> grid, int x, int z)
    {
        _grid = grid;
        this.x = x;
        this.z = z;
    }

    public TileType GetTileType()
    {
        if(type == default) SetRandomTileType(true, default);
        return type;
    }

    public void SetRandomTileType(bool random, TileType type)
    {
        if(random)
        {
            TileType randomType;

            randomType = (TileType)Random.Range(0, System.Enum.GetValues(typeof(TileType)).Length);
            this.type = randomType;
        }
        else
        {
            this.type = type;
        }
    }

    public void SetGraphics()
    {
        tileObject.GetComponent<TileVisual>().tile = this;
        tileObject.GetComponent<TileVisual>().SetTypeOnGenerate(type);
    }
}
