using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

public class UnitPlacementUI : MonoBehaviour
{
    public static UnitPlacementUI Instance;

    private VisualElement root;
    private TileVisual currentTile;

    private bool isOpen = false;


    private void Awake()
    {
        ServicesLocator.RegisterService(this);
    }

    private void OnDestroy()
    {
        ServicesLocator.UnRegisterService(this);
    }

    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<Button>("InfantryButton").clicked += () => Place(UnitType.Infantry);
        root.Q<Button>("MusketeerButton").clicked += () => Place(UnitType.Musketeer);
        root.Q<Button>("TankButton").clicked += () => Place(UnitType.Tank);

        root.style.display = DisplayStyle.None;
    }

    public void OpenMenu(TileVisual tile)
    {
        currentTile = tile;
        root.style.display = DisplayStyle.Flex;
        isOpen = true;
    }

    public void CloseMenu()
    {
        root.style.display = DisplayStyle.None;
        currentTile = null;
        isOpen = false;
    }

    void Place(UnitType type)
    {
        ServicesLocator.GetService<UnitService>().SpawnUnit(type, currentTile);
        root.style.display = DisplayStyle.None;

        CloseMenu();
    }

    void Update()
    {
        if (isOpen && Input.GetMouseButtonDown(1))
        {
            CloseMenu();
        }
    }
}
