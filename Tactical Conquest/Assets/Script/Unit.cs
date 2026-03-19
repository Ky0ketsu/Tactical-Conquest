using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitType type;

    public void Init(UnitType unitType)
    {
        type = unitType;
    }
}
