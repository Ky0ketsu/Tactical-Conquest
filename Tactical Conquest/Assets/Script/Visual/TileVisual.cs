using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class TileVisual : MonoBehaviour, ITile
{
    [SerializeField]
    public Tile tile;

    [SerializeField]
    private GameObject _graphics;

    [SerializeField]
    private GameObject[] _graphicsTile;

    [SerializeField]
    private GameObject _prefabs;

    public void OveredTile(bool isOver)
    {
        if(_graphics == null) return;

        if (isOver)
        {
            _graphics.transform.DOKill();
            _graphics.transform.DOMoveY(1f, 0.1f).SetEase(Ease.InOutCubic);
        }
        else
        {
            _graphics.transform.DOKill();
            _graphics.transform.DOMoveY(0, 0.1f).SetEase(Ease.InOutCubic);
        }
    }

    public void SetNewType(TileType tileType)
    {
        /*Debug.Log(tile.type);
        Debug.Log(tileType);*/

        if (tile.type == tileType) return;
        if (_graphicsTile[(int)tileType] != null)

        DestroyImmediate(_graphics);
        _graphics = Instantiate(_graphicsTile[(int)tileType], transform.position, Quaternion.identity, transform);
        tile.type = tileType;

        int index = tile.x * tile._grid.GridHeight + tile.z;
        tile.gridGenerator.gridData.tiles[index].type = (int)tileType;
    }

    public void SetTypeOnGenerate(TileType tileType)
    {
        DestroyImmediate(_graphics);
        _graphics = Instantiate(_graphicsTile[(int)tileType], transform.position, Quaternion.identity, transform);
    }
}
