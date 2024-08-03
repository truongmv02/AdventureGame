using UnityEngine;


public class DashAbility : Ability
{
    [SerializeField] private float dashPower = 50f;

    private float gravityScale;
    private TrailRenderer trailRenderer;
    private SpriteRenderer ownerSprite;
    protected override void Awake()
    {
        base.Awake();
        key = KeyCode.Space;
        cooldownTime = 1f;
        activeTime = 0.15f;
        trailRenderer = owner.GetComponent<TrailRenderer>();
        ownerSprite = owner.GetComponent<SpriteRenderer>();
    }
    public override void Use()
    {
        if (state != AbilityState.Ready || !owner.Movement.CanMovement ) return;
        owner.Movement.CanMove = false;
        base.Use();

        float direction = (owner.transform.localScale.x < 0f ? -1 : 1);
        owner.Rigidbody.velocity = new Vector2(owner.Rigidbody.velocity.x, 0);
        owner.Rigidbody.AddForce(Vector2.right * dashPower * direction, ForceMode2D.Impulse);

        gravityScale = owner.Rigidbody.gravityScale;
        owner.Rigidbody.gravityScale = 0;

        trailRenderer.emitting = true;
        ownerSprite.enabled = false;

    }

    public override void OnActive()
    {
    }
    public override void EndActive()
    {
        owner.Rigidbody.velocity = Vector2.zero;
        owner.Movement.CanMove = true;
        owner.Rigidbody.gravityScale = gravityScale;
        trailRenderer.emitting = false;
        ownerSprite.enabled = true; 
    }

}