using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [Header("Grid Setting")]

    private List<GameObject> _spawnedTiles = new List<GameObject>();

    public int gridWight = 10;
    public int gridHeight = 10;
    public float sizeOfCell = 1;
    public Vector3 origin = Vector3.zero;

    public GridSystem<Tile> _grid;

    [SerializeField]
    private GameObject _prefab;

    public void Start()
    {
        if(transform.childCount > 0)
        {
            for (int x = 0; x < transform.childCount; x++)
            {
                _spawnedTiles.Add(transform.GetChild(x).gameObject);
            }
            GenerateGrid();
        }
        else
        {
            GenerateGrid();
        }
        
    }

    public void GenerateGrid()
    {
        _grid = new GridSystem<Tile>
        (
            gridWight,
            gridHeight,
            sizeOfCell,
            origin,
            (GridSystem<Tile> Grid, int x, int z) =>
            {
                Tile tile = new Tile(Grid,  x, z);
                tile.SetRandomTileType();
                tile.isActive = true;
                return tile;
            }
        );

        SpawnTile();
    }

    /*private void OnDrawGizmos()
    {
        if (_grid == null) return;

        for(int x = 0; x < _grid.GridWidth; x++)
        {
            for(int z = 0; z < _grid.GridHeight; z++)
            {
                Tile tile = _grid.GetGridObject(x, z);

                Gizmos.color = tile.isActive ? Color.red : Color.green;
                Vector3 pos = _grid.GetWorldPosition(x, z);
                Gizmos.DrawWireCube(pos + Vector3.one * _grid.SizeOfCell * 0.5f, Vector3.one * _grid.SizeOfCell);
            }
        }
    }*/

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
                    obj.GetComponent<TileVisual>().tile = tile;
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
}
