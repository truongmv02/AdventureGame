using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Image currentHealth;

    public Health health;

    private void Awake()
    {
        currentHealth = transform.GetChild(1).GetComponent<Image>();
    }

    private void Start()
    {
        health = GameManager.Instance.Character.GetComponent<Health>();
        health.Healed += ChangeHealth;
        health.Damaged += ChangeHealth;
    }

    private void ChangeHealth(int value)
    {
        currentHealth.fillAmount = health.CurrentHealth / (float)health.TotalHealth;
    }

}