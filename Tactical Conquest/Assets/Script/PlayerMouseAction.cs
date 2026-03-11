using UnityEngine;

public class PlayerMouseAction : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetButtonDown("ClickLeft"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.transform.GetComponent<IClickable>() != null)
                {
                    hit.transform.GetComponent<IClickable>().ClickLeft();
                }
            }
        }
    }
}
