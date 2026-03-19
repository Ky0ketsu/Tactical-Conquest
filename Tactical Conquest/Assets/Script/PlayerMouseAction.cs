using DG.Tweening.Core.Easing;
using UnityEngine;

public class PlayerMouseAction : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }

    void HandleClick()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            TileVisual tile = hit.collider.GetComponentInParent<TileVisual>();

            if (tile != null)
            {
                OnTileClicked(tile);
            }
        }
    }

    void OnTileClicked(TileVisual tile)
    {
        switch (ServicesLocator.GetService<GameService>().CurrentState)
        {
            case ClickState.Idle:
                Debug.Log("Idle click");
                tile.Select();
                break;

            /*case ClickState.LevelEditor:
                Debug.Log("Place unit");
                tile.PlaceUnit();
                break;*/

            case ClickState.Attack:
                Debug.Log("Attack tile");
                tile.Attack();
                break;
        }
    }
}
