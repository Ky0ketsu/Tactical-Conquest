using UnityEngine;

public class GridService : MonoBehaviour
{
    void Awake()
    {
        ServicesLocator.RegisterService(this);    
    }

    void OnDestroy()
    {
        ServicesLocator.UnRegisterService(this);
    }

    private GridSystem<Tile> grid;
}
