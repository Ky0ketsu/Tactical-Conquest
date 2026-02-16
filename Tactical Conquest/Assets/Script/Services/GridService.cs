using UnityEngine;

public class GridService : MonoBehaviour
{


    void Start()
    {
        ServicesLocator.RegisterService(this);    
    }

    void OnDestroy()
    {
        ServicesLocator.UnRegisterService(this);
    }
}
