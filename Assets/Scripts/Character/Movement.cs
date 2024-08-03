using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody2D rigid;
    private BoxCollider2D boxCollider;

    [SerializeField] private float speed = 7;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 14;
    [SerializeField] private float doubleJumpForce = 12;
    [SerializeField] private int jumpCount;

    public bool CanMove { set; get; }
    public bool CanMovement { set; get; }

    public float Speed { set => speed = value; get => speed; }
    public float JumpForce { set => jumpForce = value; get => jumpForce; }
    public float DoubleJumpForce { set => doubleJumpForce = value; get => doubleJumpForce; }
    public int JumpCount { set => jumpCount = value; get => jumpCount; }


    public enum MovementState { Idle, Run, Jump, DoubleJump, Fall, Hurt }


    public LayerMask ground;    

    public bool OnGround
    {
        get
        {
            Bounds colBounds = boxCollider.bounds;
            Vector2 origin = new Vector2(colBounds.center.x, colBounds.min.y);
            Vector2 size = new Vector2(colBounds.size.x, 0.1f);
            var hit = Physics2D.BoxCast(origin, size, 0, Vector2.down, 0.1f, ground);
            return hit.collider != null;
        }
    }


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        ground = LayerMask.GetMask("Ground");
        CanMove = true;
        CanMovement = true;
    }

    protected void Update()
    {
        if (OnGround) jumpCount = 0;
    }

    protected virtual void FixedUpdate()
    {

        if (!CanMove || !CanMovement) return;

        float direction = Input.GetAxisRaw("Horizontal");
        Move(direction);
        // flip
        if (direction != 0)
        {
            var localScale = transform.localScale;
            transform.localScale = new Vector3(Mathf.Abs(localScale.x) * direction, localScale.y, localScale.z);
        }

    }

    public void Move(float direction)
    {
        if (!OnGround && direction == 0) return;
        var velocity = rigid.velocity;
        rigid.velocity = new Vector2(direction * speed, velocity.y);
    }

    public void Jump(float force)
    {
        if (!CanMovement) return;
        var velocity = rigid.velocity;
        rigid.velocity = new Vector2(velocity.x, force);
    }
}