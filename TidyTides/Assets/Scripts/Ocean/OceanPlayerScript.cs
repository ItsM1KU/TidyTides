using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class OceanPlayerScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] LayerMask BoatLayer;
    [SerializeField] LayerMask garbageLayer;
    [SerializeField] TextMeshProUGUI interactText;


    private OceanMovement oceanMovement;
    private Vector2 movement;

    private void Awake()
    {
        oceanMovement = new OceanMovement();
    }

    private void OnEnable()
    {
        oceanMovement.Enable();
    }

    private void OnDisable()
    {
        oceanMovement.Disable();
    }

    private void Update()
    {
        movement = oceanMovement.Player.Move.ReadValue<Vector2>();

        if (Physics2D.OverlapCircle(rb.position, 0.5f, BoatLayer))
        {
            interactText.gameObject.SetActive(true);

            if (oceanMovement.Player.Interact.IsPressed())
            {
                Debug.Log("Leaving ocean!!");
            }
        }
        else if(Physics2D.OverlapCircle(rb.position, 0.2f, garbageLayer))
        {
            interactText.gameObject.SetActive(true);
            var garbage = Physics2D.OverlapCircle(rb.position, 0.5f, garbageLayer);
            if (oceanMovement.Player.Interact.IsPressed())
            {
                Destroy(garbage.gameObject);
            }
        }
        else
        {
            interactText.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = (movement * moveSpeed);
    }

}
