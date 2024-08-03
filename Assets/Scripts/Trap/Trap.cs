using UnityEngine;

public class Trap : MonoBehaviour
{

    [SerializeField] private int damage = 1;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Health health = other.GetComponent<Health>();
            health.TakeDamage(damage);
          
        }
    }
}