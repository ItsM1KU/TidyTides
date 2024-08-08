using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed = 2.5f;
    [SerializeField] LayerMask boatLayer;
    [SerializeField] TextMeshProUGUI InteractText;


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

        if (Physics2D.OverlapCircle(rb.position, 0.5f, boatLayer)){

            InteractText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("You have entered the ocean!!");
            }
        }
        else
        {
            InteractText.gameObject.SetActive(false);
        }
    }
}
