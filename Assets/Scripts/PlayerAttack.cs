using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Called when the projectile collides with something
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // If the collided object has the "enemy" tag, reduce its HP
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                // Adjust the damage amount as needed
                float damageAmount = 10f;
                enemyHealth.TakeDamage(damageAmount);
            }
        }

    
    }
}