using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] float speed;

    private Vector2 movement;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x < 0)
            {
                // Flip the sprite to face left
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (direction.x > 0)
            {
                // Flip the sprite to face right
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + (movement * speed * Time.deltaTime));
    }
}
