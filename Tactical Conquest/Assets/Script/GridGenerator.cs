using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [Header("Grid Setting")]

    private List<GameObject> _spawnedTiles = new List<GameObject>();

    public int gridWight = 10;
    public int gridHeight = 10;
    public float sizeOfCell = 1;
    public Vector3 origin = Vector3.zero;
    public TileType defaultType;

    public GridSystem<Tile> _grid;

    [SerializeField]
    private GameObject _prefab;

    public GridData gridData = new GridData();


    public void Awake()
    {
        if (transform.childCount > 0)
        {
            for (int x = 0; x < transform.childCount; x++)
            {
                _spawnedTiles.Add(transform.GetChild(x).gameObject);
            }
            GenerateGrid(false);
        }
        else
        {
            GenerateGrid(false);
        }

    }

    public void GenerateGrid(bool LoadSetting, int x = 0, int z = 0)
    {
        gridData.tiles.Clear();

        if (LoadSetting)
        {

            _grid = new GridSystem<Tile>
            (
                x,
                z,
                sizeOfCell,
                origin,
                (GridSystem<Tile> Grid, int x, int z) =>
                {
                    Tile tile = new Tile(Grid, x, z);
                    tile.SetRandomTileType(false, defaultType);
                    tile.gridGenerator = this;
                    tile.isActive = true;
                    TileData data = new TileData();
                    data.x = x;
                    data.z = z;
                    data.type = TypeToInt(defaultType);
                    gridData.tiles.Add(data);
                    return tile;
                }
            );
        }
        else
        {
            _grid = new GridSystem<Tile>
            (
                gridWight,
                gridHeight,
                sizeOfCell,
                origin,
                (GridSystem<Tile> Grid, int x, int z) =>
                {
                    Tile tile = new Tile(Grid, x, z);
                    tile.SetRandomTileType(false, defaultType);
                    tile.gridGenerator = this;
                    tile.isActive = true;
                    TileData data = new TileData();
                    data.x = x;
                    data.z = z;
                    data.type = TypeToInt(defaultType);
                    gridData.tiles.Add(data);
                    return tile;
                }
            );
            SpawnTile();
        }
    }


    public int TypeToInt(TileType type)
    {
        return (int)type;
    }

    private void SpawnTile()
    {
        ClearSpawnedTiles();

        for (int x = 0; x < gridWight; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                Tile tile = _grid.GetGridObject(x, z);
                if (tile != null)
                {
                    GameObject prefab = _prefab;
                    Vector3 pos = _grid.GetWorldPosition(x, z) + (Vector3.right + Vector3.forward) * _grid.SizeOfCell * 0.5f;

                    if(z % 2 == 1)
                    {
                        pos += Vector3.right * _grid.SizeOfCell * 0.5f;
                    }

                    GameObject obj = Instantiate(prefab, pos, Quaternion.identity, transform);
                    tile.tileObject = obj;
                    tile.SetGraphics();
                    _spawnedTiles.Add(obj);
                }
            }
        }
    }
    
    public void ClearSpawnedTiles()
    {
        if (_spawnedTiles == null) return;

        foreach (GameObject obj in _spawnedTiles)
        {
            DestroyImmediate(obj);
        }
        _spawnedTiles.Clear();

        if (transform.childCount > 0)
        {
            for (int x = transform.childCount - 1; x >= 0; x--)
            {
                DestroyImmediate(transform.GetChild(x).gameObject);
            }
        }
    }

    public void LoadMap(GridData data)
    {
        ClearSpawnedTiles();

        int maxX = 0;
        int maxZ = 0;

        foreach(TileData tileData in data.tiles)
        {
            if(tileData.x +1 >= maxX) maxX = tileData.x +1;
            if(tileData.z +1 >= maxZ) maxZ = tileData.z +1;
        }
        Debug.Log(maxX + maxZ);
        GenerateGrid(true, maxX, maxZ);


        foreach ( TileData tileData in data.tiles)
        {
            Tile tile = _grid.GetGridObject(tileData.x, tileData.z);
                if (tile != null)
                {
                    GameObject prefab = _prefab;
                    Vector3 pos = _grid.GetWorldPosition(tileData.x, tileData.z) + (Vector3.right + Vector3.forward) * _grid.SizeOfCell * 0.5f;

                    if (tileData.z % 2 == 1)
                    {
                        pos += Vector3.right * _grid.SizeOfCell * 0.5f;
                    }

                    tile.SetRandomTileType(false, (TileType)tileData.type );
                    GameObject obj = Instantiate(prefab, pos, Quaternion.identity, transform);
                    tile.tileObject = obj;
                    tile.SetGraphics();
                    _spawnedTiles.Add(obj);
                }
        }
    }
}
