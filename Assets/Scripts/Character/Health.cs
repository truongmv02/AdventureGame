using UnityEngine;
using System;
public class Health : MonoBehaviour
{
    [SerializeField] private int totalHealth = 3;
    public int TotalHealth => totalHealth;
    private int currentHealth;
    public int CurrentHealth => currentHealth;

    public event Action<int> Healed = delegate { };
    public event Action<int> Damaged = delegate { };


    private void Awake()
    {
        currentHealth = totalHealth;
    }

    public void Heal(int health)
    {
        currentHealth = Mathf.Clamp(currentHealth + health, 0, totalHealth);
        Healed.Invoke(health);

    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, totalHealth);
        Damaged.Invoke(damage);
    }
}