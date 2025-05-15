using System;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class PlayerMovement : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    InputController inputs;
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask groundedRCLayerMask;

    AttackControler attackController;
    public bool grounded {  get; private set; }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputs = GetComponent<InputController>();
        attackController = GetComponent<AttackControler>();
    }

    private void OnEnable()
    {
        inputs.OnJumpEvent += HandleOnJump;
    }

    private void OnDisable()
    {
        inputs.OnJumpEvent += HandleOnJump;
    }

    private void FixedUpdate()
    {
        //Origin, direction, distance, collision filter

        grounded = Physics2D.Raycast(transform.position, Vector2.down, 1.05f, groundedRCLayerMask);
        if (attackController.isAttacking)
        {
            rb.linearVelocityX = 0;
            return;
        }
        rb.linearVelocityX = inputs.moveDir * speed;
    }

    private void HandleOnJump(object sender, EventArgs e) 
    {
        //Origin, direction, distance, collision filter.
        if(Physics2D.Raycast(transform.position, Vector2.down, 1.05f, groundedRCLayerMask))
        {
            rb.linearVelocityY = jumpForce;
        }
    }
}
