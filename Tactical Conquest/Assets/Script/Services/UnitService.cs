using UnityEngine;
using UnityEngine.Rendering;

public class UnitService : MonoBehaviour
{
    private void Awake()
    {
        ServicesLocator.RegisterService(this);
    }

    private void OnDestroy()
    {
        ServicesLocator.UnRegisterService(this);
    }

    public GameObject infantryPrefab;
    public GameObject musketeerPrefab;
    public GameObject tankPrefab;

    public void SpawnUnit(UnitType type, TileVisual tile)
    {
        GameObject prefab = GetPrefab(type);

        GameObject unitGO = Instantiate(prefab, tile.transform.position, Quaternion.identity);

        Unit unit = unitGO.GetComponent<Unit>();
        unit.Init(type);
    }

    GameObject GetPrefab(UnitType type)
    {
        switch (type)
        {
            case UnitType.Infantry: return infantryPrefab;
            case UnitType.Musketeer: return musketeerPrefab;
            case UnitType.Tank: return tankPrefab;
        }
        return null;
    }
}
