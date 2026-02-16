using UnityEngine;
using UnityEngine.InputSystem;


public class ToolLevel : MonoBehaviour
{
    [HideInInspector]
    public bool isEditing;

    [Header("Visual Setting")]
    public float overOffsetY;


    [Header("Setting")]
    public LayerMask layer;
    public TileType tileType;

    public void ChangeEditState()
    {
        isEditing = !isEditing;
        Debug.Log(isEditing);
    }

    [HideInInspector]
    TileVisual currentTile;
    [HideInInspector]
    Tile currentTileSelected;

    private void Update()
    {

        if (!isEditing) return;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
        {
            if (hit.transform.GetComponentInParent<ITile>() != null)
            {
                if(currentTile == null) currentTile = hit.transform.GetComponentInParent<TileVisual>();

                if (currentTile != hit.transform.GetComponentInParent<TileVisual>())
                {
                    currentTile.OveredTile(false);
                    currentTile = hit.transform.GetComponentInParent<TileVisual>();
                    currentTile.OveredTile(true);
                }
            }
        }
        else
        {
            if (currentTile != null)
            {
                currentTile.OveredTile(false);
                currentTile = null;
            }
            
        }

        if(Mouse.current.leftButton.wasPressedThisFrame && currentTile != null)
        {
            SelectTile();
            currentTile.SetType(tileType);
        }
    }

    public void SelectTile()
    {
        currentTileSelected = currentTile.tile;
    }
    
}
