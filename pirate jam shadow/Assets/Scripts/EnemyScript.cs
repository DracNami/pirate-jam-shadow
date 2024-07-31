using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public bool tagged;
    GameObject Player;
    public float Speed = 1f;
    public bool dmgP = false;
    PlayerStats pStats;
    public float atksPerSecond=0.5f;
    public int dmg = 1;
    float atkTimer = 0f;
    public int maxHealth = 60;
    public int health = 60;
    void Start()
    {
        Player = FindObjectOfType<PlayerController>().gameObject;
        pStats = Player.gameObject.GetComponent<PlayerStats>();
        health = maxHealth;
    }
    public void TakeDmg(int value)
    {
        health -= value;
        AudioManager.Instance.PlaySFX2d("FoeHurt");
    }
    void Update()
    {
        if (health <= 0)
        {
            FindObjectOfType<EnemySpawner>().curEnemies--;
            Destroy(this.gameObject);
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, Player.transform.position, Speed * Time.deltaTime);
        if (dmgP&&atkTimer>=atksPerSecond)
        {
            pStats.TakeDamage(dmg);
            atkTimer = 0;   
        }
        atkTimer += Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dmgP = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dmgP = false;
        }
    }
}
