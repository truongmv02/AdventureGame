using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{

    private BoxCollider2D boxColli;
    private Rigidbody2D rigid;
    private Animator animator;
    private Movement movement;

    private Health health;

    public Health Health => health;

    public BoxCollider2D BoxColli => boxColli;
    public Rigidbody2D Rigidbody => rigid;
    public Animator Animator => animator;
    public Movement Movement => movement;



    protected virtual void Awake()
    {
        boxColli = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movement = GetComponent<Movement>();
        health = GetComponent<Health>();
    }

    private void Start()
    {
        health.Damaged += Damaged;
    }

    private void Damaged(int value)
    {
        animator.Play("Hurt");
        rigid.velocity = Vector2.zero;
        Movement.CanMovement = false;

        if (health.CurrentHealth > 0)
        {
            StartCoroutine(GoToCheckPoint());
        }
        else
        {
            StartCoroutine(GameManager.Instance.GameOver());
        }
    }

    private IEnumerator GoToCheckPoint()
    {
        yield return new WaitForSeconds(1.2f);
        Movement.CanMovement = true;
        transform.position = GameManager.Instance.CharSpawnPosition;
        animator.Play("Idle");
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Item"))
    //     {
    //         Item item = other.GetComponent<Item>();
    //         item.Collect();
    //     }
    // }

}