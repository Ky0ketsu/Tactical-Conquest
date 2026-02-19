using UnityEngine;
using System;

public class Event
{
    static void ConsoleEvent(string nameEvent)
    {
        Debug.Log(nameEvent);
    }

    public static event Action OnCameraCanMove;
    public static void InvokeCameraVanMove(bool canMove)
    {
        ConsoleEvent($"Camera move is {canMove}");
        OnCameraCanMove?.Invoke();
    }
}
