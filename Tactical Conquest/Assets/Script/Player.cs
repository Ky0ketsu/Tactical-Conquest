using UnityEngine;

public class Player : MonoBehaviour
{
    public void StartTurn()
    {
        Debug.Log(name + " commence son tour");
    }

    public void EndTurn()
    {
        Debug.Log(name + " termine son tour");
    }
}
