using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 20;
    public float damageCooldown = 1.5f;

    private float lastDamageTime;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time >= lastDamageTime + damageCooldown)
            {
                PlayerHealth health = other.GetComponent<PlayerHealth>();

                if (health != null)
                {
                    health.TakeDamage(damage);
                    lastDamageTime = Time.time;
                }
            }
        }
    }
}