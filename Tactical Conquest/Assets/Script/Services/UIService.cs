using UnityEngine;
using UnityEngine.UIElements;

public class UIService : MonoBehaviour
{
    private Button nextTurnButton;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        nextTurnButton = root.Q<Button>("nextTurnButton");

        nextTurnButton.clicked += OnNextTurnClicked;
    }

    void OnNextTurnClicked()
    {
        ServicesLocator.GetService<TurnService>().NextTurn();
    }
}
