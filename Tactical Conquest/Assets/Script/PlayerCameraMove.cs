using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraMove : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField]
    private bool _canMove;
    [SerializeField]
    public float dragSpeed = 0.05f;

    private Mouse mouse;

    void Start()
    {
        mouse = Mouse.current;
    }

    void Update()
    {
        if (mouse == null) return;

        // Si clic molette maintenu
        if (mouse.middleButton.isPressed)
        {
            Vector2 delta = mouse.delta.ReadValue();

            Vector3 move = new Vector3(-delta.x, 0, -delta.y) * dragSpeed;

            transform.Translate(move, Space.World);
        }
    }
}
