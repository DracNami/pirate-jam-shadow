using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyScript enemy = collision.GetComponent<EnemyScript>();
            if (enemy != null && !enemy.tagged)//taking double damage, fix
            {
                enemy.TakeDmg(10);
            }
            else if(enemy != null && enemy.tagged)
            {
                enemy.TakeDmg(20);
            }

        }
    }
}
