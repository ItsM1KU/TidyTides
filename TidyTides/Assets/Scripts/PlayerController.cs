using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed = 2.5f;
    [SerializeField] LayerMask oceanLayer;

    //[SerializeField] float oxygenTank = 10.0f;

    private PlayerInputs playerInputs;
    private Vector2 movement;

    private void Awake()
    {
        playerInputs = new PlayerInputs();
    }

    private void OnEnable()
    {   
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }

    private void FixedUpdate()
    {
        rb.velocity = (movement * moveSpeed);
    }

    private void Update()
    {
        movement = playerInputs.Player.Move.ReadValue<Vector2>();

        if (Physics2D.OverlapCircle(rb.position, 1f, oceanLayer))
        {
            rb.gravityScale = 1.5f;
            //Debug.Log("In water");
        }
        else
        {
            rb.gravityScale = 0;
        }
      
    }
}
