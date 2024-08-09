using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class OceanPlayerScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] LayerMask BoatLayer;
    [SerializeField] TextMeshProUGUI interactText;
    [SerializeField] TextMeshProUGUI OxyText;
    [SerializeField] float oxygenLevel = 20f;

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

    private void Start()
    {
        StartCoroutine(Oxycoroutine(oxygenLevel));
    }

    private void Update()
    {
        movement = oceanMovement.Player.Move.ReadValue<Vector2>();

        if (Physics2D.OverlapCircle(rb.position, 0.5f, BoatLayer))
        {
            interactText.gameObject.SetActive(true);

            if(oceanMovement.Player.Interact.ReadValue<float>() > 0)
            {
                Debug.Log("Leaving ocean!!");
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

    IEnumerator Oxycoroutine(float oxy)
    {
        //float oxyleft = 20;
        while(oxy >= 0)
        {
            oxy -= 0.5f;
            yield return new WaitForSeconds(3f);
            Debug.Log(oxy + " Left");
            OxyText.text = ("Oxygen Level: " + oxy.ToString() + " / 20");
        }
        
    }
}
