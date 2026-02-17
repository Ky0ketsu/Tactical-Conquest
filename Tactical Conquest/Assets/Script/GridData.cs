using System.Collections.Generic;

[System.Serializable]
public class GridData
{
    public List<TileData> tiles = new List<TileData>();
}

[System.Serializable]
public class TileData
{
    public int x;
    public int z;
    public int type;
}
