using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    private Animator animator;
    [SerializeField] float force = 25;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, force);
            animator.Play("Jump");
        }
    }
}
