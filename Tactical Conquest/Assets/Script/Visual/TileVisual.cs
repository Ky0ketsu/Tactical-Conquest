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

    public void SetType(TileType tileType)
    {
        Debug.Log(tile.type);
        Debug.Log(tileType);

        if (tile.type == tileType) return;
        if (_graphicsTile[(int)tile.type] != null)

        DestroyImmediate(_graphics);
        _graphics = Instantiate(_graphicsTile[(int)tile.type], transform.position, Quaternion.identity);
        tile.type = tileType;
        
    }
}
