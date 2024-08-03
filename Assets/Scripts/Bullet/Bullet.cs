using UnityEngine;


public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed = 20;
    public float direction;

    private Rigidbody2D rigid;

    private bool canMove = true;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (gameObject.activeInHierarchy && canMove)
        {
            Debug.Log($"{transform.position.y}");
            rigid.velocity = Vector2.right * direction * speed;
            // transform.Rotate(0, 0, 45f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Other") || other.CompareTag(transform.tag)) return;

        canMove = false;
        rigid.velocity = Vector2.zero;
    }

}