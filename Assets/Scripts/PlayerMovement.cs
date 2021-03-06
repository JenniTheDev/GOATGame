using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private MainInput controller;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Awake()
    {
        controller = new MainInput();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        controller.GoatActions.Enable();
    }

    private void OnDisable()
    {
        controller.GoatActions.Disable();
    }

    private void FixedUpdate()
    {
        moveInput = controller.GoatActions.Movement.ReadValue<Vector2>();
        rb.velocity = moveInput * moveSpeed;
    }
}