using System.Collections.Generic;
using UnityEngine;

public class TurnService : MonoBehaviour
{
    public List<Player> players = new List<Player>();

    private int currentPlayerIndex = 0;

    private void Awake()
    {
        ServicesLocator.RegisterService(this);
    }

    private void OnDestroy()
    {
        ServicesLocator.UnRegisterService(this);
    }


    public Player CurrentPlayer
    {
        get { return players[currentPlayerIndex]; }
    }

    void Start()
    {
        StartTurn();
    }

    public void NextTurn()
    {
        EndTurn();

        currentPlayerIndex++;

        if (currentPlayerIndex >= players.Count)
            currentPlayerIndex = 0;

        StartTurn();
    }

    void StartTurn()
    {
        Debug.Log("Tour de : " + CurrentPlayer.name);
        CurrentPlayer.StartTurn();
    }

    void EndTurn()
    {
        CurrentPlayer.EndTurn();
    }
}
