using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rig;
    public float moveSpeed = 7f;
    private float moveX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rig.linearVelocity = new Vector2(moveX, rig.linearVelocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            Vector2 moveInput = context.ReadValue<Vector2>();
            moveX = moveInput.x * moveSpeed;
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
           moveX = 0f;
        }
    }
}
