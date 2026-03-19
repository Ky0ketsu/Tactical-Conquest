using DG.Tweening.Core.Easing;
using UnityEngine;

public class GameService : MonoBehaviour
{
    private void Awake()
    {
        ServicesLocator.RegisterService(this);
    }

    private void OnDestroy()
    {
        ServicesLocator.UnRegisterService(this);
    }

    public ClickState CurrentState = ClickState.Idle;

    public void SetState(ClickState newState)
    {
        CurrentState = newState;
        Debug.Log("New State: " + newState);
    }
}
