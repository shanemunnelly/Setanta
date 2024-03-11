using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float HP = 50;
    public Progress prog; // Reference to the PlayerStyle script


    public void TakeDamage(float damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            prog.IncreaseProgresse(1.0f);
            Destroy(gameObject);
        }
    }
}