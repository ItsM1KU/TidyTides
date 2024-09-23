using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwim : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    [SerializeField] float moveSpeed;
    Vector2 MovDir;
    [SerializeField] bool dirL;
    [SerializeField] bool dirR;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MovDir = new Vector2(1f, 0f);
    }

    private void FixedUpdate()
    {
        if (dirR)
        {
            rb.velocity = MovDir * moveSpeed;
            anim.SetBool("dirL", dirL);
        }
        else if(dirL)
        {
            rb.velocity = MovDir * -moveSpeed;
            anim.SetBool("dirL", dirL);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RightBoundary")
        {
            dirL = true;
            dirR = false;
        }
        else if (collision.gameObject.tag == "LeftBoundary")
        {
            dirR = true;
            dirL = false;
        }
    }

}
