using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingObjects : MonoBehaviour
{
    private float Zrotate;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Zrotate = Random.Range(0f, 0.5f);
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector2.up * 0.5f);
        transform.Rotate(0, 0, Zrotate);
    }
}
