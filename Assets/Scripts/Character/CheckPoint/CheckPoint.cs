using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private bool isOut = false;
    private Animator animator;
    Vector2 spawnPosition;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spawnPosition = transform.GetChild(0).position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isOut == false && other.CompareTag("Player"))
        {
            GameManager.Instance.CharSpawnPosition = spawnPosition;
            isOut = true;
            animator.Play("CheckPointOut");
        }
    }

}