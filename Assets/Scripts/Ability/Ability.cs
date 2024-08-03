using UnityEngine;

public class Ability : MonoBehaviour
{
    public float cooldownTime;
    public float activeTime;
    private float elapsedCooldownTime;
    private float elapsedActiveTime;

    protected enum AbilityState { Ready, Active, Cooldown }

    protected AbilityState state = AbilityState.Ready;

    public Character owner;

    protected KeyCode key;
    protected virtual void Awake()
    {
        owner = transform.parent.parent.GetComponent<Character>();
    }

    private void Update()
    {
        
        switch (state)
        {
            case AbilityState.Ready:
                {
                    if (Input.GetKeyDown(key))
                    {
                        Use();
                    }
                    break;
                }
            case AbilityState.Active:
                {
                    elapsedActiveTime -= Time.deltaTime;
                    if (elapsedActiveTime > 0)
                    {
                        OnActive();
                    }
                    else
                    {
                        EndActive();
                        state = AbilityState.Cooldown;
                    }
                    elapsedCooldownTime -= Time.deltaTime;
                    break;
                }
            case AbilityState.Cooldown:
                {
                    elapsedCooldownTime -= Time.deltaTime;
                    if (elapsedCooldownTime <= 0f)
                    {
                        state = AbilityState.Ready;
                    }
                    break;
                }
        }
    }

    public virtual void Use()
    {
        state = AbilityState.Active;
        elapsedActiveTime = activeTime;
        elapsedCooldownTime = cooldownTime;
    }

    public virtual void BeginActive() { }
    public virtual void OnActive() { }
    public virtual void EndActive() { }

}