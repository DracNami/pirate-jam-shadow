using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResonanceAOEScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyScript enemy = collision.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                enemy.TakeDmg(10);
                PlayerStats.instance.health += 3;
                PlayerStats.instance.healthBar.value = PlayerStats.instance.health;
            }
            
        }
    }
}
