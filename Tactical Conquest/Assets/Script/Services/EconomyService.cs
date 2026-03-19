using System.Collections.Generic;
using Unity.Multiplayer.PlayMode;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EconomyService : MonoBehaviour
{
    public List<float> money;

    private void Awake()
    {
        ServicesLocator.RegisterService(this);
    }

    private void OnDisable()
    {
        ServicesLocator.UnRegisterService(this);
    }

    public void Purchase(int currentPlayer, float cost)
    {
        if(cost >= 0) Debug.LogWarning("Valeur d'achat erroné ( " +  cost + " )");

        money[currentPlayer] -= cost;
        Debug.Log($"nouveau solde {money[currentPlayer]}");
    }

    public void MoneyIncome(int currentPlayer, float income)
    {
        if (income <= 0) Debug.LogWarning($"Valeur des revenus erroné ( {income} ) ");
        money[currentPlayer] += income;
    }
}
