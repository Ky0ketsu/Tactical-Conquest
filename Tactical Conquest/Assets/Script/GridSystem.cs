using UnityEngine;

public class GridSystem<TGridObject>
{
    private int _gridHeight;
    public int GridHeight { get { return _gridHeight; } }

    private int _gridWidth;
    public int GridWidth { get { return _gridWidth; } }

    private float _sizeOfCell;
    public float SizeOfCell { get { return _sizeOfCell; } }

    private Vector3 _originPosition;
    private TGridObject[,] _gridObjects;

    public GridSystem(int gridHeight, int gridWidht, float sizeOfCell, Vector3 originPosition, System.Func<GridSystem<TGridObject>, int, int, TGridObject> createGridObject)
    {
        this._gridHeight = gridHeight;
        this._gridWidth = gridWidht;
        this._sizeOfCell = sizeOfCell;
        this._originPosition = originPosition;

        _gridObjects = new TGridObject[gridWidht, gridHeight];

        for (int x = 0; x < gridWidht; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                _gridObjects[x, z] = createGridObject(this, x, z);
            }
        }
    }

    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x * _sizeOfCell, 0, z * _sizeOfCell * 0.85f) + _originPosition;
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - _originPosition).x /  _sizeOfCell);
        y = Mathf.FloorToInt((worldPosition - _originPosition).y / _sizeOfCell);
    }

    public TGridObject GetGridObject(int x, int z)
    {
        if (x >= 0 && z >= 0 && x < _gridWidth && z < _gridHeight) return _gridObjects[x, z];
        else return default;
    }
}
