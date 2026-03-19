using UnityEngine;

public class GridPresetLoader : MonoBehaviour
{
    GridGenerator gridGenerator;

    private void Awake()
    {
        gridGenerator = GetComponent<GridGenerator>();
    }

    public void GridLoader(int x, int z)
    {
        gridGenerator.gridData.tiles.Clear();

        gridGenerator._grid = new GridSystem<Tile>
            (
                x,
                z,
                gridGenerator.sizeOfCell,
                gridGenerator.origin,
                (GridSystem<Tile> Grid, int x, int z) =>
                {
                    Tile tile = new Tile(Grid, x, z);
                    tile.SetRandomTileType(false, gridGenerator.defaultType);
                    tile.gridGenerator = gridGenerator;
                    tile.isActive = true;
                    TileData data = new TileData();
                    data.x = x;
                    data.z = z;
                    data.type = (int)gridGenerator.defaultType;
                    gridGenerator.gridData.tiles.Add(data);
                    return tile;
                }
            );
    }

    public void LoadMap(GridData data)
    {
        gridGenerator.ClearSpawnedTiles();

        int maxX = 0;
        int maxZ = 0;

        foreach (TileData tileData in data.tiles)
        {
            if (tileData.x + 1 >= maxX) maxX = tileData.x + 1;
            if (tileData.z + 1 >= maxZ) maxZ = tileData.z + 1;
        }
        Debug.Log(maxX + maxZ);
        gridGenerator.GenerateNewGrid();


        foreach (TileData tileData in data.tiles)
        {
            Tile tile = gridGenerator._grid.GetGridObject(tileData.x, tileData.z);
            if (tile != null)
            {
                GameObject prefab = gridGenerator._prefab;
                Vector3 pos = gridGenerator._grid.GetWorldPosition(tileData.x, tileData.z) + (Vector3.right + Vector3.forward) * gridGenerator._grid.SizeOfCell * 0.5f;

                if (tileData.z % 2 == 1)
                {
                    pos += Vector3.right * gridGenerator._grid.SizeOfCell * 0.5f;
                }

                tile.SetRandomTileType(false, (TileType)tileData.type);
                GameObject obj = Instantiate(prefab, pos, Quaternion.identity, transform);
                tile.tileObject = obj;
                tile.SetGraphics();
                gridGenerator._spawnedTiles.Add(obj);
            }
        }
    }
}
