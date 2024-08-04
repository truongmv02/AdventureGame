using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Animator animator;
    private bool isCollected = false;
    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            Collect();
        }
    }



    public virtual void Collect()
    {
        isCollected = true;
        animator.Play("Collect");
    }

    public void Collected()
    {
        Destroy(gameObject);
    }
}
